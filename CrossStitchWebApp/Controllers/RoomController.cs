using CrossStitchWebApp.Data;
using CrossStitchWebApp.Interfaces;
using CrossStitchWebApp.Models;
using CrossStitchWebApp.Repository;
using CrossStitchWebApp.Services;
using CrossStitchWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrossStitchWebApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoomController(IRoomRepository roomRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _roomRepository = roomRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Room> rooms = await _roomRepository.GetAll();
            return View(rooms);  
        }

        public async Task<IActionResult> Detail(int id)
        {
            Room room = await _roomRepository.GetByIdAsync(id);
            return View(room);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createRoomViewModel = new CreateRoomViewModel { AppUserId = curUserId };
            return View(createRoomViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoomViewModel roomVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(roomVM.Image);

                var room = new Room
                {
                    Title = roomVM.Title,
                    Description = roomVM.Description,
                    Image = result.Url.ToString(),
                    AppUserId = roomVM.AppUserId,
                    Address = new Address
                    {
                        City = roomVM.Address.City,
                        Street = roomVM.Address.Street,
                        State = roomVM.Address.State
                    }
                };
                _roomRepository.Add(room);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(roomVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            if (room == null) return View("Error");
            var roomVM = new EditRoomViewModel
            {
                Title = room.Title,
                Description = room.Description,
                AddressId = room.AddressId,
                Address = room.Address,
                URL = room.Image,
                RoomCategory = room.RoomCategory
            };
            return View(roomVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRoomViewModel roomVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", roomVM);
            }

            var userRoom = await _roomRepository.GetByIdNoTracking(id);

            if (userRoom != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userRoom.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delete photo");
                    return View(roomVM);
                }
                var photoResult = await _photoService.AddPhotoAsync(roomVM.Image);
                var room = new Room
                {
                    Id = id,
                    Title = roomVM.Title,
                    Description = roomVM.Description,
                    Image = photoResult.Url.ToString(),
                    AddressId = roomVM.AddressId,
                    Address = roomVM.Address,
                };

                _roomRepository.Update(room);
                return RedirectToAction("Index");
            }
            else
            {
                return View(roomVM);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var roomDetails = await _roomRepository.GetByIdAsync(id);
            if (roomDetails == null) return View("Error");
            return View(roomDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var roomDetails = await _roomRepository.GetByIdAsync(id);
            if (roomDetails == null) return View("Error");

            _roomRepository.Delete(roomDetails);
            return RedirectToAction("Index");
        }
    }
}
