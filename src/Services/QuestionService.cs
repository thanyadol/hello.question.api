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
    }

    public class QuestionService : IQuestionService
    {
        //question status
        protected readonly IQuestionRepository _questionRepository;


        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));

            //logg
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();
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