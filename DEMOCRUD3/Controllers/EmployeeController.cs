using DEMOCRUD3.Model;
using DEMOCRUD3.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMOCRUD3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {

        private IEmployee EmployeeService;
        public EmployeeController(IEmployee employee)
        {
            EmployeeService = employee;
        }
        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = EmployeeService.GetEmployees();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("employee not found");
            }
        }


        [HttpGet]
        [Route("GetEmployeeById/{Id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            var result = EmployeeService.GetEmployeeById(Id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("employee not found");
            }
        }

        [HttpPost]

        public IActionResult Post(Employee employee)
        {
            var result = EmployeeService.PostEmployee(employee);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{Id}")]
        public IActionResult Delete(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            else
            {
                var result = EmployeeService.DeleteEmployee(Id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Update(Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();

            }
            else
            {
                var result = EmployeeService.UpdateEmployee(emp);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }

            }


        }
    }
}


