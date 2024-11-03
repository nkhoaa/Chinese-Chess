using CChess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CChess.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[AllowAnonymous]
        public IActionResult Index()
        {
            Response.Headers.Add("Cache-Control", "no-store");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Expires", "-1");
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
        
        private static List<string> userList = new List<string>();
        public IActionResult JoinRoom(string roomId)
        {
            // Retrieve the username from claims
            string username = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "Guest";

            // Add the user to the list if not already present
            if (!userList.Contains(username))
            {
                userList.Add(username);
            }

            ViewBag.UserList = userList;
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
