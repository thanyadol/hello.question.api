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

    public interface IChoiseService
    {
        Task<Choise> CreateAsync(Choise choise);
        //Task<Choise> UpdateAsync(Choise choise);
        //Task<Choise> DeleteAsync(string id);

        Task<Choise> GetAsync(Guid id);

        Task<IEnumerable<Choise>> ListAsync();
        Task<Choise> EnforceChoiseExistenceAsync(Guid id);
        Task<IEnumerable<Choise>> ListChoiseAsync();
        Task<IEnumerable<SubChoise>> ListSubChoiseAsync();
    }

    public class ChoiseService : IChoiseService
    {
        //choise status
        protected readonly IChoiseRepository _choiseRepository;
   protected readonly ISubChoiseRepository _subChoiseRepository;


        public ChoiseService(IChoiseRepository choiseRepository, ISubChoiseRepository subChoiseRepository)
        {
            _choiseRepository = choiseRepository ?? throw new ArgumentNullException(nameof(choiseRepository));
            _subChoiseRepository = subChoiseRepository ?? throw new ArgumentNullException(nameof(subChoiseRepository));

            //logg
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();
        }

        public async Task<Choise> CreateAsync(Choise choise)
        {
            var entity = await _choiseRepository.CreateAsync(choise);
            if (entity == null)
            {
                throw new ChoiseNotCreatedException();
            }

            return entity;
        }

        public async Task<Choise> GetAsync(Guid id)
        {
            var entity = await _choiseRepository.GetAsync(id);
            return entity;
        }


        public async Task<IEnumerable<Choise>> ListAsync()
        {
            return await _choiseRepository.ListAsync();
        }

        public async Task<IEnumerable<SubChoise>> ListSubChoiseAsync()
        {
            return await _subChoiseRepository.ListAsync();
        }



        public async Task<IEnumerable<Choise>> ListChoiseAsync()
        {
            return await _choiseRepository.ListChoiseAsync();
        }



        public async Task<Choise> EnforceChoiseExistenceAsync(Guid id)
        {
            var transaction = await _choiseRepository.GetAsync(id);

            if (transaction == null)
            {
                throw new ChoiseNotFoundException();
            }

            return transaction;
        }
    }

}