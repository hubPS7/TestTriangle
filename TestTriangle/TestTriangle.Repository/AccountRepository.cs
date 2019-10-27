using TestTriangle.Contracts;
using TestTriangle.Entities;
using TestTriangle.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTriangle.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(TestTriangleContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Account>> AccountsByOwner(Guid ownerId)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId))
                .ToListAsync();
        }
    }
}
