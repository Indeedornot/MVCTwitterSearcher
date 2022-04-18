using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using MVCTwitterScraper.Models;
using MVCTwitterScraper.Models.Twitter;

namespace MVCTwitterScraper.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(
            [MaxLength(50), MinLength(4)] string? username)
        {
            var usernameValidationState = ModelState.GetFieldValidationState(nameof(username));
            if (usernameValidationState == ModelValidationState.Invalid)
            {
                RouteValueDictionary routeInfo = new() { { "username", username } };
                return RedirectToAction("InvalidData", routeInfo);
            }

            var userTweetsModel = await UserTweetsModel.CreateModel(username);
            return View(userTweetsModel);
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index_Post(
            [MaxLength(50), MinLength(4), Required] string? username)
        {
            var usernameValidationState = ModelState.GetFieldValidationState(nameof(username));
            if (usernameValidationState == ModelValidationState.Invalid)
            {
                RouteValueDictionary routeInfo = new() { { "username", username } };
                return RedirectToAction("InvalidData", routeInfo);
            }

            var userTweetsModel = await UserTweetsModel.CreateModel(username);
            return View(userTweetsModel);
        }

        public IActionResult InvalidData(string username)
        {
            ViewBag.Username = username;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}