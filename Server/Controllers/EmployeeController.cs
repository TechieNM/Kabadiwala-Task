using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrud.Shared.Data;
using BlazorCrud.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BlazorCrud.Shared.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet("")]
        public List<EmployeeModel> Index()
        {
            return _employee.GetAllEmployees();
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] EmployeeModel employees)
        {
            if (ModelState.IsValid)
            {
                _employee.AddEmployee(employees);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public EmployeeModel GetEmployeeById(int id)
        {
            return _employee.GetEmployeeById(id);
        }

        [HttpPut("")]
        public IActionResult Edit([FromBody] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                _employee.UpdateEmployee(employee);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employee.DeleteEmployee(id);
        }
    }
}
