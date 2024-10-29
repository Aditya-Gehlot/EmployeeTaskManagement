using EmployeeTaskManagement.Models;
using Microsoft.AspNetCore.Mvc;
using RepoEmployeeTask.Models;
using ServiceEmployeeTask.Interfaces;

namespace EmployeeTaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                var employees = await _IEmployeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if you have a logging mechanism
                return StatusCode(500, "An error occurred while retrieving employees.");
            }
        }

        [HttpGet("getEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _IEmployeeService.GetEmployeeByIdAsync(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if you have a logging mechanism
                return StatusCode(500, "An error occurred while retrieving the employee.");
            }
        }

        [HttpPost("createEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDto employee)
        {
            try
            {
                var createdEmployee = await _IEmployeeService.AddEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if you have a logging mechanism
                return StatusCode(500, "An error occurred while creating the employee.");
            }
        }

        [HttpPut("updateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                var updatedEmployee = await _IEmployeeService.UpdateEmployeeAsync(employee);
                if (updatedEmployee == null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if you have a logging mechanism
                return StatusCode(500, "An error occurred while updating the employee.");
            }
        }

        [HttpDelete("deleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var deleted = await _IEmployeeService.DeleteEmployeeAsync(id);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if you have a logging mechanism
                return StatusCode(500, "An error occurred while deleting the employee.");
            }
        }
    }
}
