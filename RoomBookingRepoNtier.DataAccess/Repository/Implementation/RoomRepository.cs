using Microsoft.EntityFrameworkCore;
using RoomBookingRepoNtier.DataAccess.Repository.Interface;
using RoomBookingRepoNtier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Implementation
{
    public class RoomRepository : GenericRepository<RoomEntity>, IRoomRepository
    {
        private readonly DatabaseContext _context;
        public RoomRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task CreateRoomAsync(RoomEntity room)
        {
            await _context.Rooms.AddAsync(room);
        }

        public async Task EditroomAsync( RoomEntity room)
        {
            _context.Rooms.Update(room);

        }

        public async Task<RoomEntity> GetRoomDetailsAsync(int? id)
        {
          if (id == null)
            {
                return null;
            }
          var room = await _context.Rooms.Where(r => r.Id == id).FirstOrDefaultAsync();
            return room;
        }

        public async Task DeleteRoomAsync(int? id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
            
        }

    }
    
}
