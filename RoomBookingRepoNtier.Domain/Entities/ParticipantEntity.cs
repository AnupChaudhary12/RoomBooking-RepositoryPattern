using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.Domain.Entities
{
    public class ParticipantEntity
    {
        public int Id { get; set; }


        public int? BookingEntityId { get; set; }
        public BookingEntity? Booking { get; set; }
        [Required]
        [ForeignKey("ApplicationUser")]
        public string? UserId { get; set; }
    }
}
