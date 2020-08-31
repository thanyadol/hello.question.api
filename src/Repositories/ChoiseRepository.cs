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

    public interface IChoiseRepository
    {
        Task<IEnumerable<Choise>> ListAsync();


        Task<Choise> GetAsync(Guid id);
        Task<Choise> CreateAsync(Choise choise);
        Task<Choise> UpdateAsync(Choise choise);

        Task<IEnumerable<Choise>> CreateRangeAsync(IEnumerable<Choise> choises);

        //Task<Choise> DeleteAsync(Guid id);
    }

    public class ChoiseRepository : IChoiseRepository
    {

        private readonly NorthwindContext _context;
        public ChoiseRepository(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        }


        public async Task<IEnumerable<Choise>> CreateRangeAsync(IEnumerable<Choise> choises)
        {
            await _context.Choises.AddRangeAsync(choises);
            _context.SaveChanges();

            return choises;
        }


        public async Task<Choise> CreateAsync(Choise choise)
        {

            var entity = await _context.Choises.AddAsync(choise);
            _context.SaveChanges();

            return entity.Entity;
        }

        public async Task<Choise> DeleteAsync(Guid id)
        {
            var entity = await _context.Choises.FindAsync(id);
            _context.Choises.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<Choise>> ListAsync()
        {

            var entities = await _context.Choises.ToListAsync();
            return entities;
        }

        public async Task<Choise> UpdateAsync(Choise choise)
        {

            var entity = await _context.Choises.FindAsync(choise.Id);
            _context.Choises.Update(choise);

            _context.SaveChanges();
            return entity;
        }

        public async Task<Choise> GetAsync(Guid id)
        {
            var entity = await _context.Choises.FindAsync(id);
            return entity;
        }


    }
}