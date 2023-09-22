using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoomBookingRepoNtier.DataAccess;
using RoomBookingRepoNtier.DataAccess.Repository.Interface;
using RoomBookingRepoNtier.Domain.ViewModels;

namespace RoomBookingRepoNtier.Controllers.Admin
{
    
    public class AdminBookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminBookingController(IUnitOfWork unitOfWork , UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IActionResult BookRoom()
        {
            if (ViewBag.Rooms == null)
            {
                ViewBag.Rooms = _unitOfWork.RoomEntity.GetAll();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookRoom(int RoomModelId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var userId = User.Identity.Name;

                if (string.IsNullOrEmpty(userId))
                {
                    return NotFound("User not found");
                }

                var bookingSuccessful = await _unitOfWork.BookingEntity.BookRoomAsync(RoomModelId, userId, startTime, endTime);

                if (!bookingSuccessful)
                {
                    return NotFound("Room booking was not successful. Please check room availability and the selected time slot.");
                }
                return RedirectToAction(nameof(GetAllBooking));

            }
            catch (Exception ex)
            {
                // Handle exceptions if needed
                // For example, you can log the exception and display an error message
                return RedirectToAction("GetAllRoom","AdminRoom"); // Redirect to a suitable page
            }
        }

        public IActionResult GetAllBooking()
        {
            var booking = _unitOfWork.BookingEntity.GetAll();
            return View(booking);
        }

        public async Task<IActionResult> GetBookingDetails(int id)
        {

            var bookings = await _unitOfWork.BookingEntity.GetBookingsByRoomIdAsync(id);
            var viewModel = new BookingListViewModel
            {
                RoomEntityId = id,
                Bookings = bookings.ToList()

            };
            return View(viewModel);
        }
    }
}
