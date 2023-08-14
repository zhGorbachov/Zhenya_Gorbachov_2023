using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AuthApp.Models;

namespace AuthApp.Controllers;

public class HomeController : Controller
{
    private readonly List<User> Users = new List<User>()
    {
        new User() { Id = new Guid(), Username = "user1", Password = "qwerty", IsAdmin = false },
        new User() { Id = new Guid(), Username = "user2", Password = "qwerty123", IsAdmin = false },
        new User() { Id = new Guid(), Username = "admin", Password = "admin", IsAdmin = true },
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/")]
    public IActionResult Index(string message)
    {
        ViewBag.Error = message;
        return View();
    }

    [Route("/home")]
    public IActionResult Home(User user)
    {
        return View(user);
    }

    [Route("/login")]
    public IActionResult CheckUser(User user)
    {
        var checkedUser = Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

        if (checkedUser == null)
        {
            return RedirectToAction("Index", new { message = "Username or password is incorrect" });
        }
        return RedirectToAction("Home", checkedUser);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}