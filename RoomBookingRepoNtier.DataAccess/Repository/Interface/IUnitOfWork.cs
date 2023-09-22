using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IRoomRepository RoomEntity { get; }
        IBookingRepository BookingEntity { get; }
        IAddParticipantRepository ParticipantEntity { get; }
        int Save();
        
    }
}
