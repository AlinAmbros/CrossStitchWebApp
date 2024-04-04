using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrossStitchWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname{ get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
