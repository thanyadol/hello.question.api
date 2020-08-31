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

    public interface ISubChoiseRepository
    {
        Task<IEnumerable<SubChoise>> ListAsync();


        Task<SubChoise> GetAsync(Guid id);
        Task<SubChoise> CreateAsync(SubChoise subchoise);
        Task<SubChoise> UpdateAsync(SubChoise subchoise);

        Task<IEnumerable<SubChoise>> CreateRangeAsync(IEnumerable<SubChoise> subchoises);

        //Task<SubChoise> DeleteAsync(Guid id);
    }

    public class SubChoiseRepository : ISubChoiseRepository
    {

        private readonly NorthwindContext _context;
        public SubChoiseRepository(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        }


        public async Task<IEnumerable<SubChoise>> CreateRangeAsync(IEnumerable<SubChoise> subchoises)
        {
            await _context.SubChoises.AddRangeAsync(subchoises);
            _context.SaveChanges();

            return subchoises;
        }


        public async Task<SubChoise> CreateAsync(SubChoise subchoise)
        {

            var entity = await _context.SubChoises.AddAsync(subchoise);
            _context.SaveChanges();

            return entity.Entity;
        }

        public async Task<SubChoise> DeleteAsync(Guid id)
        {
            var entity = await _context.SubChoises.FindAsync(id);
            _context.SubChoises.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<SubChoise>> ListAsync()
        {

            var entities = await _context.SubChoises.ToListAsync();
            return entities;
        }

        public async Task<SubChoise> UpdateAsync(SubChoise subchoise)
        {

            var entity = await _context.SubChoises.FindAsync(subchoise.Id);
            _context.SubChoises.Update(subchoise);

            _context.SaveChanges();
            return entity;
        }

        public async Task<SubChoise> GetAsync(Guid id)
        {
            var entity = await _context.SubChoises.FindAsync(id);
            return entity;
        }


    }
}