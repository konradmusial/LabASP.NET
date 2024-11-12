using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    public IActionResult Calculator(Operators op, double? x, double? y)
    {

        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby x lub y lub ich brak!";
            return View("KalkulatorError");
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
            default:
                ViewBag.ErrorMessage = "Nieznany operator!";
                return View("KalkulatorError");
                
        }
        ViewBag.Result = result;
        ViewBag.x = x;
        ViewBag.y = y;
        ViewBag.op = op;
        return View();
    }
    public enum Operators

    {
        Add, Sub, Div, Mul
    }
    // GET
    public IActionResult Form()
    {
        return View();
    }
    public IActionResult Result()
    {
        return View();
    }
}