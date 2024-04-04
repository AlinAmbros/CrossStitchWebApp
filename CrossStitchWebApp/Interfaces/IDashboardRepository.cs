using CrossStitchWebApp.Models;

namespace CrossStitchWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Room>> GetAllUserRooms();
        Task<List<Club>> GetAllUserClubs();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser club);
        bool Save();
    }
}
