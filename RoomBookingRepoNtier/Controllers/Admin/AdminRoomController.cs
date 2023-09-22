using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomBookingRepoNtier.DataAccess;
using RoomBookingRepoNtier.DataAccess.Repository.Interface;
using RoomBookingRepoNtier.Domain.Entities;

namespace RoomBookingRepoNtier.Controllers.Admin
{
    public class AdminRoomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminRoomController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

		public IActionResult GetAllRoom()
		{
			var room = _unitOfWork.RoomEntity.GetAll();
			return View(room);
		}
		public async Task<IActionResult> GetRoomDetails(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var room = await _unitOfWork.RoomEntity.GetRoomDetailsAsync(id);
			if (room == null)
			{
				return NotFound();
			}
			return View(room);
		}
		public IActionResult CreateRoom()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRoom(RoomEntity room)
		{
			if (ModelState.IsValid)
			{
				await _unitOfWork.RoomEntity.CreateRoomAsync(room);
				_unitOfWork.Save();
				return RedirectToAction(nameof(GetAllRoom));
			}
			return View(room);
		}
		public IActionResult EditRoom(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var room = _unitOfWork.RoomEntity.FirstOrDefault(r => r.Id == id);
			if (room == null)
			{
				return NotFound();
			}
			return View(room);
		}
		[HttpPost]
		public async Task<IActionResult> EditRoom(int id, RoomEntity room)
		{
			if (id != room.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				try
				{
					await _unitOfWork.RoomEntity.EditroomAsync(room);
					_unitOfWork.Save();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (_unitOfWork.RoomEntity.FirstOrDefault(r => r.Id == id) == null)
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(GetAllRoom));
			}
			return View(room);
		}

		public async Task<IActionResult> DeleteRoom(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var room = await _unitOfWork.RoomEntity.GetRoomDetailsAsync(id);
			if (room == null)
			{
				return NotFound();
			}
			return View(room);
		}
		[HttpPost, ActionName("DeleteRoom")]
		public async Task<IActionResult> DeleteRoomConfirmed(int id)
		{
			await _unitOfWork.RoomEntity.DeleteRoomAsync(id);
			_unitOfWork.Save();
			return RedirectToAction(nameof(GetAllRoom));
		}
	}
}
