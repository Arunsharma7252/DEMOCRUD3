using DEMOCRUD3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCRUD3.Repository.Contract.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeService(ApplicationDbContext
            _dbContext)
        {
            dbContext = _dbContext;
        }

        public Employee DeleteEmployee(int Id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == Id);
            if (emp != null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return emp;
            }
            return null;
        }

        public Employee GetEmployeeById(int Id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == Id);
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public Employee PostEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }




        public Employee UpdateEmployee(Employee emp)
        {
            var eee = dbContext.Employees.SingleOrDefault(e => e.Id == emp.Id);
            if (eee != null)
            {
                eee.FirstName = emp.FirstName;
                eee.LastName = emp.LastName;
                eee.Email = emp.Email;
                eee.Address = emp.Address;

                dbContext.Employees.Update(eee);
                dbContext.SaveChanges();
                return emp;
            }
            return null;
        }
    }
    
}
