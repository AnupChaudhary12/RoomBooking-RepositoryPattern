﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.Domain.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UserId { get; set; }
        public int RoomEntityId { get; set; }
        public RoomEntity? RoomEntity { get; set; }
        public ICollection<ParticipantEntity>? Participants { get; set; }
    }
}
