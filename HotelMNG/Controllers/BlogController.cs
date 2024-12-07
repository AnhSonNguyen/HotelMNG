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
}
