using CrossStitchWebApp.Data.Enum;
using CrossStitchWebApp.Models;

namespace CrossStitchWebApp.ViewModel
{
    public class EditRoomViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public RoomCategory RoomCategory { get; set; }
    }
}
