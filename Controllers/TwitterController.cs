
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MVCPages.Controllers
{
    public class TwitterController : Controller
    {
        [HttpGet]
        public IActionResult Index(
            [MaxLength(50)]
            [MinLength(4)]
            string? username)
        {
            var usernameValidationState = ModelState.GetFieldValidationState(nameof(username));
            if (usernameValidationState == ModelValidationState.Invalid)
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
        public IActionResult Index_Post(
            [MaxLength(50)]
            [MinLength(4)]
            [Required]
            string? username)
        {
            var usernameValidationState = ModelState.GetFieldValidationState(nameof(username));
            if (usernameValidationState == ModelValidationState.Invalid)
            {
                RouteValueDictionary routeInfo = new() { { "username", username } };
                return RedirectToAction("InvalidData", routeInfo);
            }

            //Do something

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
