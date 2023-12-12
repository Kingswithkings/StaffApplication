using System.ComponentModel.DataAnnotations;

namespace StaffApplication.StaffUsers
{
    public class StaffUserRegistration
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public string PhoneNumber { get; set; }

    }
}
