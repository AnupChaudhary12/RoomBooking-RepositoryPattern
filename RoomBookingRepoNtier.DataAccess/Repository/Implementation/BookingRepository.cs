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
    public class BookingRepository : GenericRepository<BookingEntity>, IBookingRepository
    {
        private readonly DatabaseContext _context;
        public BookingRepository(DatabaseContext context): base(context)
        {
            _context = context;
        }


        public async Task<bool> BookRoomAsync(int RoomModelId, string userId, DateTime startTime, DateTime endTime)
        {
            var room =  _context.Rooms.Include(r => r.Bookings)
                .FirstOrDefault(r => r.Id == RoomModelId);
            if (room == null)
            {
                return false;
            }
            if (room.Status==" NotAvailable")
            {
                return false;
            }
            if (room.Bookings.Any(b => b.StartTime <= startTime && b.EndTime >= startTime) || room.Bookings.Any(b => b.StartTime <= endTime && b.EndTime >= endTime) || room.Bookings.Any(b => b.StartTime >= startTime && b.EndTime <= endTime))
            
                {
                return false;
            }
            var booking = new BookingEntity
            {
                UserId = userId,
                RoomEntityId = RoomModelId,
                StartTime = startTime,
                EndTime = endTime
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<BookingEntity>> GetBookingsByRoomIdAsync(int? RoomModelId)
        {
            var bookings = await _context.Bookings.Where(b => b.RoomEntityId == RoomModelId).ToListAsync();
            return bookings;
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                return false;
            }
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<BookingEntity> GetBookingDetailsAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var booking = await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync();
            return booking;
        }

        
    }
}
