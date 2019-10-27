using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTriangle.Entities.Modesl
{
    public partial class Employees : IEntity
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Addresss { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string CreatedBy { get; set; }
    }
}
