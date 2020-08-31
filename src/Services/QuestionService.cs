using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//model
using hello.question.api.Models;
using hello.question.api.Repositories;

//logg
using Serilog;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using hello.question.api.Exceptions;
using Microsoft.EntityFrameworkCore;
using hello.question.api.Extensions;
using AutoMapper;
using hello.question.api.Models.Gateway;

namespace hello.question.api.Services
{

    public interface IQuestionService
    {
        Task<Question> CreateAsync(Question question);
        //Task<Question> UpdateAsync(Question question);
        //Task<Question> DeleteAsync(string id);

        Task<Question> GetAsync(Guid id);

        Task<IEnumerable<Question>> ListAsync();
        Task<Question> EnforceQuestionExistenceAsync(Guid id);
        Task<QuestionParams> GetRemainBySessionAsync(Guid sessionid)
    }

    public class QuestionService : IQuestionService
    {
        //question status
        protected readonly IQuestionRepository _questionRepository;
        protected readonly ISubQuestionRepository _subQuestionRepository;

        protected readonly IChoiseService _choiseService;


        protected readonly IParticipantService _participantService;
        protected readonly IAnswerService _answerService;

        public QuestionService(IQuestionRepository questionRepository, ISubQuestionRepository subQuestionRepository, IParticipantService participantService, IAnswerService answerService, IChoiseService choiseService)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _subQuestionRepository = subQuestionRepository ?? throw new ArgumentNullException(nameof(subQuestionRepository));

            _participantService = participantService ?? throw new ArgumentNullException(nameof(participantService));
            _answerService = answerService ?? throw new ArgumentNullException(nameof(answerService));
            _choiseService = choiseService ?? throw new ArgumentNullException(nameof(choiseService));


            //logg
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();
        }


        //
        // Summary:
        //     get remain a question by session id for client
        //
        // Returns:
        //      question model
        //
        // Params:
        //      question model with list of mixed sub question and choise
        //

        public async Task<QuestionParams> GetRemainBySessionAsync(Guid sessionid)
        {
            //get participant session
            var participant = await _participantService.GetBySessionAsync(sessionid);
            if (participant == null)
            {
                throw new ParticipantNotFoundException();
            }

            //prepaire data
            var questions = await _questionRepository.ListAsync();
            var subQuestions = await _subQuestionRepository.ListAsync();
            var choises = await _choiseService.ListFullChoiseAsync();

            //get list of answer to compare with remain
            var recentAnswers = await _answerService.ListBySessionAsync(sessionid);
            if (recentAnswers.Any())
            {

                var temp = subQuestions.Where(c => recentAnswers.Select(y => y.SubQuestionId).ToArray().Contains(c.Id));

                //get remain question by subquestionid
                questions = questions.Where(c => !temp.GroupBy(y => y.QuestionId).Select(x => x.Key).Contains(c.Id));
            }

            //complete session with choise and subquestion by order
            var pickedQuestion = questions.OrderBy(c => c.Order).FirstOrDefault();

            //get subquestion and assign full choise
            var selectSubQuestions = subQuestions.Where(c => c.QuestionId == pickedQuestion.Id)
                                    .Select(c => { c.Choises = choises.Where(w => w.Id == c.ChoiseId).ToList(); return c; }).ToList();

            //assign choise
            var entity = new QuestionParams()
            {
                Id = pickedQuestion.Id,
                Title = pickedQuestion.Title,

                Order = pickedQuestion.Order,

                SubQuestions = selectSubQuestions,
                By = pickedQuestion.By,

                Date = pickedQuestion.Date
            };


            return entity;
        }


        public async Task<Question> CreateAsync(Question question)
        {
            var entity = await _questionRepository.CreateAsync(question);
            if (entity == null)
            {
                throw new QuestionNotCreatedException();
            }

            return entity;
        }

        public async Task<Question> GetAsync(Guid id)
        {
            var entity = await _questionRepository.GetAsync(id);
            return entity;
        }


        public async Task<IEnumerable<Question>> ListAsync()
        {
            return await _questionRepository.ListAsync();
        }


        public async Task<Question> EnforceQuestionExistenceAsync(Guid id)
        {
            var transaction = await _questionRepository.GetAsync(id);

            if (transaction == null)
            {
                throw new QuestionNotFoundException();
            }

            return transaction;
        }
    }

}