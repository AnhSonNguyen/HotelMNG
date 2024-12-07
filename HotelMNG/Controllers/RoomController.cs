using Microsoft.AspNetCore.Mvc;
using HotelMNG.Models;
using System.Linq;

public class RoomController : Controller
{
    private readonly Qlks3Context _context;

    public RoomController(Qlks3Context context)
    {
        _context = context;
    }

    public IActionResult RoomDetail(string name)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Name == name);
        if (room == null)
        {
            return NotFound();
        }
        return View(room);
    }
}
