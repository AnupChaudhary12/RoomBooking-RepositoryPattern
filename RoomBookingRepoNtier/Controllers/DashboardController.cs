using Microsoft.AspNetCore.Mvc;

namespace RoomBookingRepoNtier.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Display()
		{
			return View();
		}
	}
}
