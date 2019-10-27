using TestTriangle.Contracts;
using TestTriangle.Entities;
//using TestTriangle.Entities.Models;
using TestTriangle.Entities.Modesl;

namespace TestTriangle.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TestTriangleContext _repoContext;
        private IEmployeeRepository _employee;
        private ICountryRepository _country;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }

                return _employee;
            }
        }

        public ICountryRepository Country
        {
            get
            {
                if (_country == null)
                {
                    _country = new CountryRepository(_repoContext);
                }

                return _country;
            }
        }

        public RepositoryWrapper(TestTriangleContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
