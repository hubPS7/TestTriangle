using TestTriangle.Entities.ExtendedModels;
using TestTriangle.Entities.Modesl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTriangle.Contracts
{
    public interface ICountryRepository : IRepositoryBase<Country>
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}
