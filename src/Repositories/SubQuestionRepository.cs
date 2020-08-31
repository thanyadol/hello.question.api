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

    public interface ISubQuestionRepository
    {
        Task<IEnumerable<SubQuestion>> ListAsync();


        Task<SubQuestion> GetAsync(string id);
        Task<SubQuestion> CreateAsync(SubQuestion subquestion);
        Task<SubQuestion> UpdateAsync(SubQuestion subquestion);

        Task<IEnumerable<SubQuestion>> CreateRangeAsync(IEnumerable<SubQuestion> subquestions);

        //Task<SubQuestion> DeleteAsync(string id);
    }

    public class SubQuestionRepository : ISubQuestionRepository
    {

        private readonly NorthwindContext _context;
        public SubQuestionRepository(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        }


        public async Task<IEnumerable<SubQuestion>> CreateRangeAsync(IEnumerable<SubQuestion> subquestions)
        {
            await _context.SubQuestions.AddRangeAsync(subquestions);
            _context.SaveChanges();

            return subquestions;
        }


        public async Task<SubQuestion> CreateAsync(SubQuestion subquestion)
        {

            var entity = await _context.SubQuestions.AddAsync(subquestion);
            _context.SaveChanges();

            return entity.Entity;
        }

        public async Task<SubQuestion> DeleteAsync(string id)
        {
            var entity = await _context.SubQuestions.FindAsync(id);
            _context.SubQuestions.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<SubQuestion>> ListAsync()
        {

            var entities = await _context.SubQuestions.ToListAsync();
            return entities;
        }

        public async Task<SubQuestion> UpdateAsync(SubQuestion subquestion)
        {

            var entity = await _context.SubQuestions.FindAsync(subquestion.Id);
            _context.SubQuestions.Update(subquestion);

            _context.SaveChanges();
            return entity;
        }

        public async Task<SubQuestion> GetAsync(string id)
        {
            var entity = await _context.SubQuestions.FindAsync(id);
            return entity;
        }


    }
}