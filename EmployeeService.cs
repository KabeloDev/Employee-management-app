using Employee_DomainLayer.Models;
using Employee_RepositoryLayer.IRepository;
using Employee_ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_ServiceLayer.CustomServices
{
    public class EmployeeService : ICustomService<Employee>
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }
        public Employee Get(int id)
        {
            return _repository.Get(id);
        }
        public void Create (Employee employee)
        {
            _repository.Create(employee);
            _repository.SaveChanges();
        }
        public void Update(Employee employee)
        {
            _repository.Update(employee);
            _repository.SaveChanges();
        }
        public void Delete(Employee employee)
        {
            _repository.Delete(employee);
            _repository.SaveChanges();
        }
    }
}
