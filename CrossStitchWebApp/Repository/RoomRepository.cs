using CrossStitchWebApp.Data;
using CrossStitchWebApp.Interfaces;
using CrossStitchWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrossStitchWebApp.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool Add(Room room)
        {
            _context.Add(room);
            return Save();
        }

        public bool Delete(Room room)
        {
            _context.Remove(room);
            return Save();
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRoomsByCity(string city)
        {
            return await _context.Rooms.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            return await _context.Rooms.Include(a => a.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Room> GetByIdNoTracking(int id)
        {
            return await _context.Rooms.Include(a => a.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Room room)
        {
            _context.Update(room);
            return Save();
        }
    }
}
