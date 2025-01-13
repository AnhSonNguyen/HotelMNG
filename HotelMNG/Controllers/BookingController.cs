using Microsoft.AspNetCore.Mvc;
using HotelMNG.Models;
using System.Linq;

namespace HotelMNG.Controllers
{
    public class BookingController : Controller
    {
        private readonly Qlks3Context _context;

        public BookingController(Qlks3Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitBooking(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra phòng trống
                var availableRoom = _context.ActualRooms
                    .Where(r => r.RoomType == model.Room && r.Status == "Available" && !r.Bookings.Any(b => b.CheckInDate <= model.CheckOutDate && b.CheckOutDate >= model.CheckInDate))
                    .FirstOrDefault();

                if (availableRoom != null)
                {
                    // Lưu thông tin đặt phòng
                    var booking = new Booking
                    {
                        ActualRoomId = availableRoom.ActualRoomId,
                        CheckInDate = model.CheckInDate,
                        CheckOutDate = model.CheckOutDate,
                        RoomType = model.Room
                    };
                    _context.Bookings.Add(booking);
                    _context.SaveChanges();

                    // Cập nhật trạng thái phòng thành "Booked"
                    availableRoom.Status = "Booked";
                    _context.SaveChanges();

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "No rooms available for your selected dates." });
                }
            }
            return Json(new { success = false, message = "Invalid data. Please check your input and try again." });
        }
    }
}
