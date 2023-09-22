using RoomBookingRepoNtier.DataAccess.Repository.Interface;
using RoomBookingRepoNtier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Implementation
{
    public class AddParticipantRepository : GenericRepository<ParticipantEntity>, IAddParticipantRepository
    {
        private readonly DatabaseContext _context;
        public AddParticipantRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
    
