using Employee_DomainLayer.Data;
using Employee_DomainLayer.Models;
using Employee_RepositoryLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_RepositoryLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : Employee
    {
        private readonly SQLiteDBContext _dbContext;
        private DbSet<T> _dbSet;

        public Repository(SQLiteDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public T Get(int id)
        {
            return _dbSet.SingleOrDefault(a => a.Id == id) ?? throw new ArgumentNullException(); 
        }

        public void Create (T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
