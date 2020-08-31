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

    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> ListAsync();


        Task<Answer> GetAsync(Guid id);
        Task<Answer> CreateAsync(Answer answer);
        Task<Answer> UpdateAsync(Answer answer);

        Task<IEnumerable<Answer>> CreateRangeAsync(IEnumerable<Answer> answers);

        //Task<Answer> DeleteAsync(Guid id);
    }

    public class AnswerRepository : IAnswerRepository
    {

        private readonly NorthwindContext _context;
        public AnswerRepository(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        }


        public async Task<IEnumerable<Answer>> CreateRangeAsync(IEnumerable<Answer> answers)
        {
            await _context.Answers.AddRangeAsync(answers);
            _context.SaveChanges();

            return answers;
        }


        public async Task<Answer> CreateAsync(Answer answer)
        {

            var entity = await _context.Answers.AddAsync(answer);
            _context.SaveChanges();

            return entity.Entity;
        }

        public async Task<Answer> DeleteAsync(Guid id)
        {
            var entity = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<Answer>> ListAsync()
        {

            var entities = await _context.Answers.ToListAsync();
            return entities;
        }


        public async Task<Answer> UpdateAsync(Answer answer)
        {

            var entity = await _context.Answers.FindAsync(answer.Id);
            _context.Answers.Update(answer);

            _context.SaveChanges();
            return entity;
        }

        public async Task<Answer> GetAsync(Guid id)
        {
            var entity = await _context.Answers.FindAsync(id);
            return entity;
        }


    }
}