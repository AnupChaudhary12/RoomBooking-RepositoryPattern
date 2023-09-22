using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.Domain.Entities
{
    public class RoomEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public string? Status { get; set; }
        public ICollection<BookingEntity>? Bookings { get; set; }
    }
}
