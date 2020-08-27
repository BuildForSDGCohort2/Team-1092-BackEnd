using Microsoft.AspNetCore.Identity;
using System;

namespace OlivetVehicleTracking.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int Country { get; set; }
        public DateTime JoiningDate { get; set; }
       
    }
}
