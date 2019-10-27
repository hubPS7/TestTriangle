using TestTriangle.Entities.Modesl;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestTriangle.Entities.ExtendedModels
{
    public class EmployeeExtended : IEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Addresss { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Photo { get; set; }
        public string Notes { get; set; }
        public string ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public string Salary { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
        //
        public EmployeeExtended()
        {
        }

        public EmployeeExtended(Employees owner)
        {
            Addresss = owner.Addresss;
            City = owner.City;
            Country = owner.Country;
            FirstName = owner.FirstName;    
            HomePhone = owner.HomePhone;
            LastName = owner.LastName;
            PostalCode = owner.PostalCode;
            Region = owner.Region;
            Title = owner.Title;
            CreatedBy = owner.CreatedBy;
        }
    }
}
