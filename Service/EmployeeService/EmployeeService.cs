using EmployeeManagement.DataContext;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagement.Service.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee)
        {
            var serviceResponse = new ServiceResponse<List<EmployeeModel>>();
            try
            {
                if (newEmployee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                }

                await _context.AddAsync(newEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Employees.ToListAsync();
            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
        {
            var serviceResponse = new ServiceResponse<List<EmployeeModel>>();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não existe";
                    serviceResponse.Success = false;
                }
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Employees.ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
        {
            var serviceResponse = new ServiceResponse<EmployeeModel>();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não existe";
                    serviceResponse.Success = false;
                }
                serviceResponse.Data = employee;

            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
        {
            var serviceResponse = new ServiceResponse<List<EmployeeModel>>();
            try
            {
                serviceResponse.Data = await _context.Employees.ToListAsync();
                if(serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "Nenhum dado encontrado!";
                }
            }catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id)
        {
            var serviceResponse = new ServiceResponse<List<EmployeeModel>>();
            try
            {   var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if(employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não existe";
                    serviceResponse.Success = false;
                }

                employee.Active = false;
                employee.ChangeDate = DateTime.UtcNow.ToLocalTime();

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Employees.ToListAsync();
            }catch (Exception ex)
            {
                serviceResponse.Message= ex.Message;
                serviceResponse.Success= false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel editEmployee)
        {   
            var serviceResponse = new ServiceResponse<List<EmployeeModel>>();
            try
            {
                var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == editEmployee.Id);
                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Usuário não existe";
                    serviceResponse.Success = false;
                }
                employee.ChangeDate = DateTime.UtcNow.ToLocalTime();
                _context.Employees.Update(editEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;

        }
    }
}
