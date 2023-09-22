using RoomBookingRepoNtier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Interface
{
    public interface IBookingRepository:IGenericRepository<BookingEntity>
    {
        Task<IEnumerable<BookingEntity>> GetBookingsByRoomIdAsync(int? RoomModelId);
        Task<bool> BookRoomAsync(int RoomModelId, string userId, DateTime startTime, DateTime endTime);
        Task<bool> DeleteBookingAsync(int bookingId);
        Task<BookingEntity> GetBookingDetailsAsync(int? id);

    }
}
