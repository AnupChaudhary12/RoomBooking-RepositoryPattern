using RoomBookingRepoNtier.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Interface
{
	public interface IUserAuthenticationService
	{
		Task<Status> LoginAsync(LoginModel model);
		Task<Status> RegistrationAsync(RegistrationModel model);
		Task LogoutAsync();
	}
}
