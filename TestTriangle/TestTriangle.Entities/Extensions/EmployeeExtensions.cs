using System;
using System.Collections.Generic;
using System.Text;
using TestTriangle.Entities.Modesl;

namespace TestTriangle.Entities.Extensions
{
    public static class EmployeeExtensions
    {
        public static void Map(this Employees dbOwner, Employees owner)
        {
            dbOwner.Addresss = owner.Addresss;
            dbOwner.City = owner.City;
            dbOwner.Country = owner.Country;
            dbOwner.FirstName = owner.FirstName;
            dbOwner.HomePhone = owner.HomePhone;
            dbOwner.LastName = owner.LastName;
            dbOwner.PostalCode = owner.PostalCode;
            dbOwner.Region = owner.Region;
            dbOwner.Title = owner.Title;
            dbOwner.CreatedBy = owner.CreatedBy;
        }
    }
}
