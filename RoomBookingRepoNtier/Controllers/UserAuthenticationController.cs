using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomBookingRepoNtier.DataAccess.Repository.Interface;
using RoomBookingRepoNtier.Domain.Models;

namespace RoomBookingRepoNtier.Controllers
{
	public class UserAuthenticationController : Controller
	{
		private readonly IUserAuthenticationService _service;
		public UserAuthenticationController(IUserAuthenticationService service)
		{
			_service = service;
		}
		 public IActionResult Registration()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Registration(RegistrationModel model)
		{
			if (!ModelState.IsValid)
			
				return View(model);
			
			model.Role = "user";
			var result = await _service.RegistrationAsync(model);
			TempData["Message"] = result.Message;	
			return RedirectToAction(nameof(Registration));
		}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _service.LoginAsync(model);
			if(result.StatusCode == 1)
			{
				return RedirectToAction("Display", "Dashboard");
			}
			else
			{
				TempData["Message"] = result.Message;
				return RedirectToAction(nameof(Login));
			}
		}
		[Authorize]
		public async Task<IActionResult> Logout()
		{
		await _service.LogoutAsync();
			return RedirectToAction(nameof(Login));
		}

		//public async Task<IActionResult> RegAdmin()
		//{
		//	var model = new RegistrationModel
		//	{
		//		UserName = "Admin",
		//		Name = "Admin",
		//		Email = "dprayansh@gmail.com",
		//		Password = "Admin@12345",
		//	};
		//	model.Role= "admin";
		//	var result = await _service.RegistrationAsync(model);
		//	return Ok(result);
		//}
	}
}
