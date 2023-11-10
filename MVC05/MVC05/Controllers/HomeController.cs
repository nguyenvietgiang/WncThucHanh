using Microsoft.AspNetCore.Mvc;
using MVC05.Models;
using MVC05.Repository;
using System.Diagnostics;

namespace MVC05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HanghoaRepository _hanghoaRepository;
        public HomeController(ILogger<HomeController> logger, HanghoaRepository hanghoaRepository)
        {
            _logger = logger;
            _hanghoaRepository = hanghoaRepository;
        }
         
        public IActionResult Index()
        {
            var hanghoaList = _hanghoaRepository.GetHanghoaList();
            return View(hanghoaList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hanghoa hanghoaViewModel, IFormFile imageFile)
        {
           await _hanghoaRepository.InsertHanghoaAsync(hanghoaViewModel.Tenhang, hanghoaViewModel.Gianiemyet, hanghoaViewModel.Dacdiem, hanghoaViewModel.Xuatxu, imageFile);
           return RedirectToAction("Index", "Home"); 
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
}