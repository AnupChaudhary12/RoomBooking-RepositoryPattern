using Microsoft.AspNetCore.Identity;
using RoomBookingRepoNtier.DataAccess.Repository.Interface;
using RoomBookingRepoNtier.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoomBookingRepoNtier.DataAccess.Repository.Implementation
{
	public class UserAuthenticationService : IUserAuthenticationService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
        public UserAuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;     
        }
        public async Task<Status> LoginAsync(LoginModel model)
		{
		    var status = new Status();
			var user =await _userManager.FindByNameAsync(model.UserName);
			if (user == null)
			{
				status.StatusCode = 0;
				status.Message = "User does not exist!";
				return status;
			}
			// check password
			if (!await _userManager.CheckPasswordAsync(user, model.Password))
			{
				status.StatusCode = 0;
				status.Message = "Invalid password!";
				return status;
			}
			var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false,true);
			if(signInResult.Succeeded)
			{
				var userRoles = await _userManager.GetRolesAsync(user);
				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
					
				};
				foreach(var userRole in userRoles)
				{
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));
				}
				status.StatusCode = 1;
				status.Message = "Login successful!";
				return status;
			}
			else if(signInResult.IsLockedOut)
			{
				status.StatusCode = 0;
				status.Message = "User locked out!";
				return status;
			}
			else
			{
				status.StatusCode = 0;
				status.Message = "Invalid login attempt!";
				return status;
			}
		}

		public async Task LogoutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<Status> RegistrationAsync(RegistrationModel model)
		{
			var status = new Status();
			var userExists =await _userManager.FindByNameAsync(model.UserName);
			if (userExists != null)
			{
				status.StatusCode = 0;
				status.Message = "User already exists!";
				return status;
			}
			ApplicationUser user = new ApplicationUser()
			{
				SecurityStamp = Guid.NewGuid().ToString(),
				Name = model.Name,
                Email = model.Email,
                UserName = model.UserName,
				EmailConfirmed = true
			};
			var result = await _userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				status.StatusCode = 0;
				status.Message = "User creation failed! Please check user details and try again.";
				return status;
			}
			// role management
			if (!await _roleManager.RoleExistsAsync(model.Role))
				await _roleManager.CreateAsync(new IdentityRole(model.Role));
			if (await _roleManager.RoleExistsAsync(model.Role))
			{
				await _userManager.AddToRoleAsync(user, model.Role);
			}
			status.StatusCode = 1;
			status.Message = "User created successfully!";	
			return status;
		}
	}
}
