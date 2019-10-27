using System;
using System.Linq;
using System.Threading.Tasks;
using TestTriangle.Contracts;
using TestTriangle.Entities.Extensions;
using TestTriangle.Entities.Modesl;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using TestTriangle.Repository;

namespace TestTriangle.API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        //private EmployeeRepository _empRepo;

        public EmployeeController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("getallemployee")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employee = await _repository.Employee.GetAllEmployeesAsync();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEmployee action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "EmployeeId")]
        [Route("getemployeebyId")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _repository.Employee.GetEmployeeByIdAsync(id);

                if (employee.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(employee);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return Ok(500);
            }
        }

        [HttpPost]
        [Route("addemployee")]
        public async Task<IActionResult> AddEmployee(Employees employee)
        {
            try
            {
                if (employee.IsObjectNull())
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                await _repository.Employee.CreateEmployeeAsync(employee);

                return Ok(new { EmployeeId = employee.EmployeeId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [Route("updaterecord")]
        public async Task<IActionResult> UpdateEmployee(int id, Employees employee)
        {
            try
            {
                if (employee.IsObjectNull())
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbOwner = await _repository.Employee.GetEmployeeByIdAsync(id);
                if (dbOwner == null || dbOwner.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await _repository.Employee.UpdateEmployeeAsync(dbOwner, employee);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _repository.Employee.GetEmployeeByIdAsync(id);
                if (employee == null || employee.IsEmptyObject())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                await _repository.Employee.DeleteEmployeeAsync(employee);

                return Ok(200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}