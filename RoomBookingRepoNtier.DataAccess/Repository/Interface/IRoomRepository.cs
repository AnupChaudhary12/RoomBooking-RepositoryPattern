using RoomBookingRepoNtier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Interface
{
    public interface IRoomRepository:IGenericRepository<RoomEntity>
    {
        Task<RoomEntity> GetRoomDetailsAsync(int? id);
        Task CreateRoomAsync(RoomEntity room);
        Task EditroomAsync( RoomEntity room);
        Task DeleteRoomAsync(int? id);
    }
}
