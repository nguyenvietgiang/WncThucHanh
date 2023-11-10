using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;

namespace MVC02.Controllers
{
    public class Bai2Controller : Controller
    {
    private readonly ILogger<HomeController> _logger;

    public Bai2Controller(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Success()
    {
        return View();
    }
    [Route("")]
    [Route("home/index")]
    public IActionResult Register()
    {
        return View();
    }
    public IActionResult Receive(string username ,string password,string email)
    {
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(email))
            {
               ViewData["Message"] = $"Xin chào {username}, Bạn đã đăng ký thành công";
                return View("Success");
            }
            else
            {
                ViewData["Message"] = "Xảy ra lỗi !!! Vui lòng đăng ký lại";
            }
            return View("Register");      
    }
    }
}
