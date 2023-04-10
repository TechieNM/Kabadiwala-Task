using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCrud.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Shared.Data
{
    public interface IEmployee
    {
        List<EmployeeModel> GetAllEmployees();
        void AddEmployee(EmployeeModel employee);
        void UpdateEmployee(EmployeeModel employee);
        EmployeeModel GetEmployeeById(int id);
        void DeleteEmployee(int id);
    }

    public class EmployeAccessLayer : IEmployee
    {
        private EmployeeDbContext _context;
        public EmployeAccessLayer(EmployeeDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                EmployeeModel emp = _context.Employees.Find(id);
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch
            {
                throw;
            }
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            try
            {
                EmployeeModel employee = _context.Employees.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
