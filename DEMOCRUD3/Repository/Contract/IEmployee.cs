using DEMOCRUD3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCRUD3.Repository.Contract
{
  public  interface IEmployee
    {
        List<Employee> GetEmployees();
        Employee PostEmployee(Employee employee);
        Employee GetEmployeeById(int Id);
     
        Employee DeleteEmployee(int Id);
        Employee UpdateEmployee(Employee emp);



    }
}
