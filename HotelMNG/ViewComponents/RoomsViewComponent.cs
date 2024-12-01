using HotelMNG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMNG.ViewComponents
{
    public class RoomsViewComponent : ViewComponent
    {
        private readonly Qlks3Context _context;

        public RoomsViewComponent(Qlks3Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.Rooms
                .OrderByDescending(m => m.RoomId)
                .ToListAsync();

            return View(items);
        }
    }
}
