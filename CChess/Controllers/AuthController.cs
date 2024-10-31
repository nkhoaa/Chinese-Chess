using Microsoft.AspNetCore.Mvc;

namespace CChess.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("AddRole")]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(Request.Scheme + "://" + Request.Host);

            var response = await client.PostAsJsonAsync("/api/Account/Add-role", roleName);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Register");
            }

            ViewBag.Message = "Error creating role.";
            return View();
        }
    }
}
