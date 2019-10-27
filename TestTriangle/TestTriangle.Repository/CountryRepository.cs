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
    class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(TestTriangleContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await FindAll()
                .OrderBy(x => x.CountryId)
                .ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int ownerId)
        {
            return await FindByCondition(o => o.CountryId.Equals(ownerId))
                .DefaultIfEmpty(new Country())
                .SingleAsync();
        }

        public async Task CreateCountryAsync(Country countries)
        {
            Create(countries);
            await SaveAsync();
        }

        public async Task UpdateCountryAsync(Country dbcountries, Employees countries)
        {
            //dbemployees.Map(employees);
            Update(dbcountries);
            await SaveAsync();
        }

        public async Task DeleteCountryAsync(Country countries)
        {
            Delete(countries);
            await SaveAsync();
        }
    }
}
