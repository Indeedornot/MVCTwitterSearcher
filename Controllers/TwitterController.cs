
using Microsoft.AspNetCore.Mvc;

namespace MVCPages.Controllers
{
    public class TwitterController : Controller
    {
        private static bool IsUsernameValid(string? username)
        {
            return username?.Length is >= 4 and <= 50;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string? username)
        {
            if (!IsUsernameValid(username))
            {
                RouteValueDictionary routeInfo = new() { { "username", username } };
                return RedirectToAction("InvalidData", routeInfo);
            }

            //Do something

            ViewBag.Username = username ?? string.Empty;
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public IActionResult Index_Post(string? username)
        {
            if (!IsUsernameValid(username))
            {
                RouteValueDictionary routeInfo = new() { { "username", username } };
                return RedirectToAction("InvalidData", routeInfo);
            }

            //Do Something

            ViewBag.Username = username ?? string.Empty;
            return View();
        }

        public IActionResult InvalidData(string username)
        {
            ViewBag.Username = username;
            return View();
        }
    }
}
