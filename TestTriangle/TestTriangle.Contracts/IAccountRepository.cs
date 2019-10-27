using TestTriangle.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTriangle.Contracts
{
    public interface IAccountRepository:IRepositoryBase<Account>
    {
        Task<IEnumerable<Account>> AccountsByOwner(Guid ownerId);
    }
}
