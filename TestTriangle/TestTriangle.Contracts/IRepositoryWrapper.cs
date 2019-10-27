using System;
using System.Collections.Generic;
using System.Text;

namespace TestTriangle.Contracts
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        ICountryRepository Country { get; }
    }
}
