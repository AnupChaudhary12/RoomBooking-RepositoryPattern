using RoomBookingRepoNtier.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            RoomEntity = new RoomRepository(_context);
            BookingEntity = new BookingRepository(_context);
            ParticipantEntity = new AddParticipantRepository(_context);
        }

        public IRoomRepository RoomEntity { get; private set; }
        public IBookingRepository BookingEntity { get; private set; }
        public IAddParticipantRepository ParticipantEntity { get; private set; }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
