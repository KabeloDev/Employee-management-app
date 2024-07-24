using Employee_DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_RepositoryLayer.IRepository
{
    public interface IRepository<T> where T : Employee
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create (T entity);
        void Update (T entity);
        void Delete (T entity);
        void SaveChanges();
    }
}
