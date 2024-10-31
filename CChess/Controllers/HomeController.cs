using CChess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CChess.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Login()
        //{
        //    // Render login view
        //    return View();
        //}
        public IActionResult PlayAnonymously(string name)
        {
            // Logic to set up an anonymous session with the provided name
            // Redirect to a main game or lobby page, or handle as needed
            return RedirectToAction("RoomList", "Home", new { name });
        }

        public IActionResult RoomList()
        {
            return View();
        }

        public IActionResult JoinRoom(string roomId)
        {
            // Pass roomId to the ChessBoard view if needed
            ViewBag.RoomId = roomId;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
