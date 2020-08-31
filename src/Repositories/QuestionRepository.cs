using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> ListAsync();

        Task<Question> GetAsync(Guid id);
        Task<Question> CreateAsync(Question question);
        Task<Question> UpdateAsync(Question question);
        //Task<Question> DeleteAsync(Guid id);

    }

    public class QuestionRepository : IQuestionRepository
    {
        private readonly NorthwindContext _context;

        public QuestionRepository(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        }

        public async Task<Question> GetAsync(Guid id)
        {

            var groups = await _context.Questions.FindAsync(id);
            //_context.SaveChanges();

            return groups;
        }


        public async Task<Question> CreateAsync(Question api)
        {
            var entity = await _context.Questions.AddAsync(api);
            _context.SaveChanges();

            return entity.Entity;
        }

        public async Task<IEnumerable<Question>> ListAsync()
        {
            var entities = await _context.Questions.ToListAsync();
            return entities;
        }

        public async Task<Question> UpdateAsync(Question question)
        {
            var entity = await _context.Questions.FindAsync(question.Id);
            _context.Questions.Update(question);

            _context.SaveChanges();
            return entity;
        }

    }
}