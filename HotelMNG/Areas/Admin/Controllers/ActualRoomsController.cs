using Microsoft.AspNetCore.Mvc;
using HotelMNG.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelMNG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ActualRoomsController : Controller
    {
        private readonly Qlks3Context _context;

        public ActualRoomsController(Qlks3Context context)
        {
            _context = context;
        }

        // GET: Admin/ActualRooms
        [Route("Admin/ActualRooms")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActualRooms.ToListAsync());
        }

        // GET: Admin/ActualRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualRoom = await _context.ActualRooms
                .FirstOrDefaultAsync(m => m.ActualRoomId == id);
            if (actualRoom == null)
            {
                return NotFound();
            }

            // Sử dụng toán tử null-coalescing để cung cấp giá trị mặc định nếu giá trị là null
            string roomType = actualRoom.RoomType ?? "Unknown";
            string status = actualRoom.Status ?? "Unknown";
            string notes = actualRoom.Notes ?? "No notes";

            return View(actualRoom);
        }

        // GET: Admin/ActualRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ActualRooms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActualRoomId,RoomNumber,RoomType,Status,Notes")] ActualRoom actualRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actualRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actualRoom);
        }

        // GET: Admin/ActualRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualRoom = await _context.ActualRooms.FindAsync(id);
            if (actualRoom == null)
            {
                return NotFound();
            }

            // Sử dụng toán tử null-coalescing để cung cấp giá trị mặc định nếu giá trị là null
            string roomType = actualRoom.RoomType ?? "Unknown";
            string status = actualRoom.Status ?? "Unknown";
            string notes = actualRoom.Notes ?? "No notes";

            return View(actualRoom);
        }

        // POST: Admin/ActualRooms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActualRoomId,RoomNumber,RoomType,Status,Notes")] ActualRoom actualRoom)
        {
            if (id != actualRoom.ActualRoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actualRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActualRoomExists(actualRoom.ActualRoomId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(actualRoom);
        }

        // GET: Admin/ActualRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualRoom = await _context.ActualRooms
                .FirstOrDefaultAsync(m => m.ActualRoomId == id);
            if (actualRoom == null)
            {
                return NotFound();
            }

            // Sử dụng toán tử null-coalescing để cung cấp giá trị mặc định nếu giá trị là null
            string roomType = actualRoom.RoomType ?? "Unknown";
            string status = actualRoom.Status ?? "Unknown";
            string notes = actualRoom.Notes ?? "No notes";

            return View(actualRoom);
        }

        // POST: Admin/ActualRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actualRoom = await _context.ActualRooms.FindAsync(id);
            _context.ActualRooms.Remove(actualRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActualRoomExists(int id)
        {
            return _context.ActualRooms.Any(e => e.ActualRoomId == id);
        }
    }
}
