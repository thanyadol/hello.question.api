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

    public interface IParticipantService
    {
        Task<Participant> CreateAsync(Participant participant);
        //Task<Participant> UpdateAsync(Participant participant);
        //Task<Participant> DeleteAsync(string id);


        Task<Participant> GetAsync(Guid id);

        Task<IEnumerable<Participant>> ListAsync();
        Task<Participant> EnforceParticipantExistenceAsync(Guid id);
    }

    public class ParticipantService : IParticipantService
    {
        //participant status
        protected readonly IParticipantRepository _participantRepository;


        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository ?? throw new ArgumentNullException(nameof(participantRepository));

            //logg
            Log.Logger = new LoggerConfiguration()
                            .WriteTo.Console()
                            .CreateLogger();
        }

        public async Task<Participant> CreateAsync(Participant participant)
        {
            var entity = await _participantRepository.CreateAsync(participant);
            if (entity == null)
            {
                throw new ParticipantNotCreatedException();
            }

            return entity;
        }

        public async Task<Participant> GetAsync(Guid id)
        {
            var entity = await _participantRepository.GetAsync(id);
            return entity;
        }


        public async Task<IEnumerable<Participant>> ListAsync()
        {
            return await _participantRepository.ListAsync();
        }


        public async Task<Participant> EnforceParticipantExistenceAsync(Guid id)
        {
            var transaction = await _participantRepository.GetAsync(id);

            if (transaction == null)
            {
                throw new ParticipantNotFoundException();
            }

            return transaction;
        }
    }

}