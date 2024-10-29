using EmployeeTaskManagement.Models;
using Microsoft.EntityFrameworkCore;
using RepoEmployeeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoEmployeeTask
{
    public class RepoEmployee
    {
        private readonly EmployeeTaskDbContext _context;

        public RepoEmployee(EmployeeTaskDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() => _context.Employees.Include(e => e.EmployeeRole).ToList();

        public Employee? GetById(int id) => _context.Employees.Include(e => e.EmployeeRole).FirstOrDefault(e => e.Id == id);

        public async Task<Employee> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }


        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
