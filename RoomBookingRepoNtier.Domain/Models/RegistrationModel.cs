using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.Domain.Models
{
	public class RegistrationModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain at least one uppercase letter, one lowercase letter, one digit and one special character.")]
		public string Password { get; set; }
		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
		public string? Role { get; set; }
	}
}
