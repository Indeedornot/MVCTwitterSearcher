using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCTwitterSearcher.Models;
using MVCTwitterSearcher.Services;

namespace MVCTwitterSearcher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITwitterService twitterService;

        public HomeController(ITwitterService twitterService)
        {
            this.twitterService = twitterService;
        }

        public async Task<IActionResult> Index(TwitterUsernameModel model)
        {
            var userTweetsModel = await twitterService.GetTweetsAsync(model.Username);
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

        public IActionResult Privacy()
        {
            return View();
        }
    }
}