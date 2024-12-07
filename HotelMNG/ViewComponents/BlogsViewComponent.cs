using HotelMNG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMNG.ViewComponents
{
    public class BlogsViewComponent : ViewComponent
    {
        private readonly Qlks3Context _context;

        public BlogsViewComponent(Qlks3Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.BlogPosts
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return View(items);
        }
    }
}
