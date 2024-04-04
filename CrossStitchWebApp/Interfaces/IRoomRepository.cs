using CrossStitchWebApp.Models;

namespace CrossStitchWebApp.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room> GetByIdAsync(int id);
        Task<Room> GetByIdNoTracking(int id);
        Task<IEnumerable<Room>> GetAllRoomsByCity(string city);
        bool Add(Room room);
        bool Update(Room room);
        bool Delete(Room room);
        bool Save();
    }
}
