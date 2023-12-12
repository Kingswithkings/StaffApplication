using StaffApplication.Models;
using System.Text.Json.Serialization;

namespace StaffApplication.Models
{
    public class Staff
    {
        [JsonIgnore]
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
