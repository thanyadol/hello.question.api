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

    public interface IAnswerService
    {
        Task<Answer> CreateAsync(Answer answer);
        //Task<Answer> UpdateAsync(Answer answer);
        //Task<Answer> DeleteAsync(string id);

        Task<Answer> GetAsync(Guid id);

        Task<IEnumerable<Answer>> ListAsync();
        Task<Answer> EnforceAnswerExistenceAsync(Guid id);
        Task<IEnumerable<Answer>> ListBySessionAsync(Guid sessionid);
    }

    public class AnswerService : IAnswerService
    {
        //answer status
        protected readonly IAnswerRepository _answerRepository;


        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository ?? throw new ArgumentNullException(nameof(answerRepository));

            //logg
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();
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


        public async Task<IEnumerable<Answer>> ListBySessionAsync(Guid sessionid)
        {
            var entities = await _answerRepository.ListQuestionAsync();

            return entities.Where(c => c.SessionId == sessionid);
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