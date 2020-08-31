using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//model
using hello.question.api.Models;
//EF
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace hello.question.api.Repositories
{
    /*
     * 
     *
     */

    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> ListAsync();


        Task<Participant> GetAsync(string id);
        Task<Participant> CreateAsync(Participant participant);
        Task<Participant> UpdateAsync(Participant participant);

        Task<IEnumerable<Participant>> CreateRangeAsync(IEnumerable<Participant> participants);

        //Task<Participant> DeleteAsync(string id);
    }

    public class ParticipantRepository : IParticipantRepository
    {

        private readonly NorthwindContext _context;
        public ParticipantRepository(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        }


        public async Task<IEnumerable<Participant>> CreateRangeAsync(IEnumerable<Participant> participants)
        {
            await _context.Participants.AddRangeAsync(participants);
            _context.SaveChanges();

            return participants;
        }


        public async Task<Participant> CreateAsync(Participant participant)
        {

            var entity = await _context.Participants.AddAsync(participant);
            _context.SaveChanges();

            return entity.Entity;
        }

        public async Task<Participant> DeleteAsync(string id)
        {
            var entity = await _context.Participants.FindAsync(id);
            _context.Participants.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<Participant>> ListAsync()
        {

            var entities = await _context.Participants.ToListAsync();
            return entities;
        }

        public async Task<Participant> UpdateAsync(Participant participant)
        {

            var entity = await _context.Participants.FindAsync(participant.Id);
            _context.Participants.Update(participant);

            _context.SaveChanges();
            return entity;
        }

        public async Task<Participant> GetAsync(string id)
        {
            var entity = await _context.Participants.FindAsync(id);
            return entity;
        }


    }
}