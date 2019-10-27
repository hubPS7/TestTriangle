using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTriangle.Contracts;
using TestTriangle.Entities;
using TestTriangle.Entities.ExtendedModels;
using TestTriangle.Entities.Extensions;
using TestTriangle.Entities.Modesl;
using Microsoft.EntityFrameworkCore;

namespace TestTriangle.Repository
{
    public class EmployeeRepository : RepositoryBase<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(TestTriangleContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            return await FindAll()
                .OrderBy(x => x.FirstName)
                .ToListAsync();
        }

        public async Task<Employees> GetEmployeeByIdAsync(int ownerId)
        {
            return await FindByCondition(o => o.EmployeeId.Equals(ownerId))
                .DefaultIfEmpty(new Employees())
                .SingleAsync();
        }

        public async Task CreateEmployeeAsync(Employees employees)
        {
            Create(employees);
            await SaveAsync();
        }

        public async Task UpdateEmployeeAsync(Employees dbemployees, Employees employees)
        {
            dbemployees.Map(employees);
            Update(dbemployees);
            await SaveAsync();
        }

        public async Task DeleteEmployeeAsync(Employees employees)
        {
            Delete(employees);
            await SaveAsync();
        }
    }
}