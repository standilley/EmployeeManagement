using EmployeeManagement.Models;
using EmployeeManagement.Service.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployees()
        {
            return Ok(await _employeeInterface.GetEmployees());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> CreateEmployee(EmployeeModel NewEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployee(NewEmployee));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeById(int id)
        {
            var response = await _employeeInterface.GetEmployeeById(id);
            return Ok(response);
        }
        [HttpPut("inactiveEmployee/{id}")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> InactiveEmployee(int id)
        {
            var response = await _employeeInterface.InactiveEmployee(id);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> UpdateEmployee(EmployeeModel editEmployee)
        {
            var response = await _employeeInterface.UpdateEmployee(editEmployee);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> DeleteEmployee(int id)
        {
            var response = await _employeeInterface.DeleteEmployee(id);
            return Ok(response);
        }

    }
}
