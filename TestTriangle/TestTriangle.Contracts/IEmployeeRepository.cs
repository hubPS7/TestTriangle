using TestTriangle.Entities.ExtendedModels;
using TestTriangle.Entities.Modesl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTriangle.Contracts
{
    public interface IEmployeeRepository:IRepositoryBase<Employees>
    {
        Task<IEnumerable<Employees>> GetAllEmployeesAsync();
        Task<Employees> GetEmployeeByIdAsync(int ownerId);
        Task CreateEmployeeAsync(Employees employees);
        Task UpdateEmployeeAsync(Employees dbEmployees, Employees Employees);
        Task DeleteEmployeeAsync(Employees Employees);
    }
}
