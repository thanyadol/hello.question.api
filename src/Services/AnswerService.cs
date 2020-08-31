using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//model
using hello.question.api.Models;
using hello.question.api.Models.Gateway;
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

namespace hello.question.api.Services
{

    public interface IAnswerService
    {
        Task<Answer> CreateAsync(Answer answer);
        //Task<Answer> UpdateAsync(Answer answer);
        //Task<Answer> DeleteAsync(string id);

        Task<Answer> GetAsync(Guid id);

        Task<IEnumerable<Answer>> ListAsync();
        Task<Answer> EnforceAnswerExistenceAsync(Guid id);
        Task<IEnumerable<Answer>> ListByParticipantAsync(Guid participantid);
        Task<IEnumerable<Answer>> BatchCreateAsync(AnswerParams param);
        Task<IEnumerable<AnswerParams>> ListAnswerDetailAsync();
    }

    public class AnswerService : IAnswerService
    {
        //answer status
        protected readonly IAnswerRepository _answerRepository;
        protected readonly IQuestionAnswerService _questionService;

        protected readonly IChoiseService _choiseService;


        public AnswerService(IAnswerRepository answerRepository, IQuestionAnswerService questionService,  IChoiseService choiseService)
        {
            _answerRepository = answerRepository ?? throw new ArgumentNullException(nameof(answerRepository));
            _questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
            _choiseService = choiseService ?? throw new ArgumentNullException(nameof(choiseService));

            //logg
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();
        }

        //
        // Summary:
        //     create range of answer
        //
        // Returns:
        //      list of created anwser model
        //
        // Params:
        //     answer param gatway
        //

        public async Task<IEnumerable<Answer>> BatchCreateAsync(AnswerParams param)
        {
            List<Answer> entities = new List<Answer>();
            //persist all of answer for earch subquestion
            foreach (var a in param.Answers)
            {
                //set some value
                a.Date = DateTime.UtcNow;
                a.ParticipantId = param.ParticipantId;

               // a.By = param.ParticipantId;
                
                entities.Add(a);
            }

            var entity = await _answerRepository.CreateRangeAsync(entities);
            if (entity == null)
            {
                throw new AnswerNotCreatedException();
            }

            return entities;
        }

        public async Task<Answer> CreateAsync(Answer answer)
        {
            var entity = await _answerRepository.CreateAsync(answer);
            if (entity == null)
            {
                throw new AnswerNotCreatedException();
            }

            return entity;
        }

        public async Task<Answer> GetAsync(Guid id)
        {
            var entity = await _answerRepository.GetAsync(id);
            return entity;
        }


        public async Task<IEnumerable<Answer>> ListAsync()
        {
            return await _answerRepository.ListAsync();
        }


        //
        // Summary:
        //     list answer and detailed question for csv
        //
        // Returns:
        //      list of anwser params
        //

        public async Task<IEnumerable<AnswerParams>> ListAnswerDetailAsync()
        {
            var answers = await _answerRepository.ListAsync();
            var questions = await _questionService.ListDetailAsync();
            var choises = await _choiseService.ListSubChoiseAsync();

            List<AnswerParams> entities = new List<AnswerParams>();
            //persist all of answer for earch subquestion
            foreach (var a in answers)
            {
                var p = new AnswerParams()
                {
                   //set some value
                    ParticipantId = a.ParticipantId,
                    AnswerDate = a.Date,
                    AnswerId = a.Id,

                    AnswerText = a.Text,
                    AnswerValue = a.Value,
                };

                //set value of choise
                var ch = choises.Where(c => c.Id == a.Value).FirstOrDefault();
                if(ch != null)
                {
                    p.AnswerText = ch.Title;
                }

                //set question and subquestion
                var q = questions.Where(c => c.Id == a.SubQuestionId).FirstOrDefault();
                if(q != null)
                {
                    p.SubQuestionId = q.Id;
                    p.QuestionId = q.QuestionId;

                    p.QuestionTitle = q.QuestionTitle;
                    p.SubQuestionValue = q.Value;

                    p.SubQuestionType = q.Type;
                    p.SubQuestionOrder  = q.Order;
                }

           
                entities.Add(p);
            }

            return entities;
        }

        public async Task<IEnumerable<Answer>> ListByParticipantAsync(Guid participantid)
        {
            var entities = await _answerRepository.ListAsync();

            return entities.Where(c => c.ParticipantId == participantid);
        }


        public async Task<Answer> EnforceAnswerExistenceAsync(Guid id)
        {
            var transaction = await _answerRepository.GetAsync(id);

            if (transaction == null)
            {
                throw new AnswerNotFoundException();
            }

            return transaction;
        }
    }

}