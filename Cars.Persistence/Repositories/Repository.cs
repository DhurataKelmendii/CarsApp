using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Cars.Domain.Entities;
using Cars.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cars.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarsDbContext _context;
        public Repository(CarsDbContext context)
        {
            _context = context;
        }


        public async Task<T> GetById(int id)
        {
            var user = await _context.Set<T>().FindAsync(id);

            return user;
        }
        public async Task Create(T model)
        {
            await _context.Set<T>().AddAsync(model);
        }

        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
        }
        public void Update(T model)
        {
            _context.Set<T>().Update(model);
        }

        public async Task<IList<T>> GetAll()
        {
                var result = await _context.Set<T>().ToListAsync();

                return result;
        }

 
        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public async Task<bool> SaveChangesAsync()
        {
            var saved = await _context.SaveChangesAsync();

            return saved > 0 ? true : false;
        }


    }
}
