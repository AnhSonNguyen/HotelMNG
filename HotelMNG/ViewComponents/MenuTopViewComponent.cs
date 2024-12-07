using HotelMNG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelMNG.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly Qlks3Context _context;
        public MenuTopViewComponent(Qlks3Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.Menus.Where(m => m.IsActive)
                .OrderBy(m => m.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
