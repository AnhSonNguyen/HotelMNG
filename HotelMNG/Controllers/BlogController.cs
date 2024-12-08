using HotelMNG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class BlogController : Controller
{
    private readonly Qlks3Context _context;

    public BlogController(Qlks3Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var blogPosts = _context.BlogPosts.ToList();
        return View(blogPosts); // Trỏ đến view Blog.cshtml
    }

    public IActionResult BlogDetail(string alias)
    {
        var blogPost = _context.BlogPosts.FirstOrDefault(b => b.Alias == alias);
        if (blogPost == null)
        {
            return NotFound();
        }
        return View(blogPost); // Trỏ đến view BlogDetail.cshtml
    }
}
