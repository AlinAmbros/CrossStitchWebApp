using CrossStitchWebApp.Data.Enum;
using CrossStitchWebApp.Models;

namespace CrossStitchWebApp.ViewModel
{
    public class CreateRoomViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
