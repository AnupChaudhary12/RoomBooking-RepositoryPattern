using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBookingRepoNtier.Domain.Entities;

namespace RoomBookingRepoNtier.Domain.ViewModels
{
    public class BookingListViewModel
    {
        public int RoomEntityId { get; set; }
        public List<BookingEntity> Bookings { get; set; }
    }
}
