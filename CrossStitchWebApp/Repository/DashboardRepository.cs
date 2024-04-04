using CrossStitchWebApp.Data;
using CrossStitchWebApp.Interfaces;
using CrossStitchWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrossStitchWebApp.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContext) 
        {
            _context = context;
            _httpContextAccessor = httpContext;
        }

        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userClubs = _context.Clubs.Where(r => r.AppUserId == curUser.GetUserId());
            return userClubs.ToList();
        }

        public async Task<List<Room>> GetAllUserRooms()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userRooms = _context.Rooms.Where(r => r.AppUserId == curUser.GetUserId());
            return userRooms.ToList();
        }

        public async Task<AppUser> GetUserById(string id) 
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdNoTracking(string id) 
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
