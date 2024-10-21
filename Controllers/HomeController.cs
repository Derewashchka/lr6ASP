using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (user.IsOldEnough())
        {
            return RedirectToAction("Order", new { userName = user.Name });
        }
        else
        {
            ViewBag.Message = "Вам повинно бути більше 16 років для замовлення.";
            return View();
        }
    }

    [HttpGet]
    public IActionResult Order(string userName)
    {
        ViewBag.UserName = userName;
        return View();
    }

    [HttpPost]
    public IActionResult Order(int productCount)
    {
        return RedirectToAction("ProductForm", new { count = productCount });
    }

    [HttpGet]
    public IActionResult ProductForm(int count)
    {
        ViewBag.Count = count;
        return View();
    }

    [HttpPost]
    public IActionResult ProductForm(List<Product> products)
    {
        return View("Summary", products);
    }
}
