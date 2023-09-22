using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomBookingRepoNtier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess
{
    public class DatabaseContext:IdentityDbContext<ApplicationUser>
	{
		public DatabaseContext(DbContextOptions<DatabaseContext>options): base(options)
		{

		}
		public DbSet<ApplicationUser> ApplicationUser { get; set; }
		public DbSet<RoomEntity> Rooms { get; set; }
		public DbSet<BookingEntity> Bookings { get; set; }
		public DbSet<ParticipantEntity> Participants { get; set; }
	}
}
