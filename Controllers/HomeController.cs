using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    /* RUTAS GET */

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(chef => chef.AllDishes).ToList();

        return View("Index", AllChefs);
    }



    [HttpPost]
    [Route("chefs/new")]
    public IActionResult ProcesaChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Chefs.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("NewChef");
    }

    [HttpGet("add/chef")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }

    [HttpGet("add/dish")]
    public IActionResult NewDish()
    {
        var allChefs = _context.Chefs.ToList();
        ViewBag.AllChefs = allChefs;
        return View("NewDish");
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
