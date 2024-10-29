using EmployeeTaskManagement.Models;
using RepoEmployeeTask;
using RepoEmployeeTask.Models;
using ServiceEmployeeTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmployeeTask.Services
{
    public class EmployeeService : IEmployeeService
    {
    
        private readonly RepoEmployee _repoEmployee;

        public EmployeeService(RepoEmployee repoEmployee)
        {
            _repoEmployee = repoEmployee;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = _repoEmployee.GetAll();
            return await Task.FromResult(employees);
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = _repoEmployee.GetById(id);
            return await Task.FromResult(employee);
        }

        public async Task<Employee> AddEmployeeAsync(EmployeeCreateDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Password = employeeDto.Password,
                EmployeeRole = employeeDto.EmployeeRole,
                EmployeeTask = null // Ensure no tasks are associated when creating the employee
            };

            return await _repoEmployee.AddAsync(employee);
        }


        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var existingEmployee = _repoEmployee.GetById(employee.Id);
            if (existingEmployee == null) return null;

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Password = employee.Password;
            existingEmployee.EmployeeRole = employee.EmployeeRole;

            _repoEmployee.Update(existingEmployee);
            return await Task.FromResult(existingEmployee);
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = _repoEmployee.GetById(id);
            if (employee == null) return false;

            _repoEmployee.Delete(employee);
            return await Task.FromResult(true);
        }
    }
}
