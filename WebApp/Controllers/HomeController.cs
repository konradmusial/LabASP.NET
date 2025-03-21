using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    
    
    /*
     * Zadanie domowe
     * Napisz metodę Age, która przyjmuje parametr z datą urodzin i wyświetla wiek
     * w latach, miesiącach i dniach.
     */

    public IActionResult Calculator(Operators? op, double? x, double? y)
    {
        //https://localhost:7182/Home/Calculator?op=div&x=8&y=4
        //var op = (Request.Query["op"]);
        //var x = double.Parse(Request.Query["x"]);
        //var y = double.Parse(Request.Query["y"]);
        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby x lub y lub brak parametru!";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CalculatorError");
        }
        
        double? result = 0.0d;
        switch (op)
        {
            case Operators.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operators.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operators.Mul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            case Operators.Div:
                result = x / y;
                ViewBag.Operator = ":";
                break;
        }
        ViewBag.Result = result;
        ViewBag.X = x;
        ViewBag.Y = y;
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
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

public enum Operators
{
    Add, Sub, Mul, Div
}