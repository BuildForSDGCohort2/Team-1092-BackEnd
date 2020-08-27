using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace OlivetVehicleTracking.Models
{
    public class RegisterModel 
    {
        [Email]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }

    }
}
