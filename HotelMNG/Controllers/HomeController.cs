using HotelMNG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Qlks3Context _context;

    public HomeController(ILogger<HomeController> logger, Qlks3Context context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Rooms()
    {
        var rooms = _context.Rooms.ToList();
        return View(rooms);
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Blog()
    {
        var blogPosts = _context.BlogPosts.ToList();
        return View("Blog", blogPosts);
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
