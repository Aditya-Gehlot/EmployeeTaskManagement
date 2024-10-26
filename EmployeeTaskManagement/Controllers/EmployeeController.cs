using EmployeeTaskManagement.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceEmployeeTask.Interfaces;
using ServiceEmployeeTask.Services;

namespace EmployeeTaskManagement.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _IEmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _IEmployeeService = employeeService;
        }

        [HttpGet("getAllEmployee")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _IEmployeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("getEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _IEmployeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost("createEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            var createdEmployee = await _IEmployeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var updatedEmployee = await _IEmployeeService.UpdateEmployeeAsync(employee);
            if (updatedEmployee == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("deleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _IEmployeeService.DeleteEmployeeAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
