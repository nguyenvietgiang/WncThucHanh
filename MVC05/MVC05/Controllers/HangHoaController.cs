using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MVC05.Models;
using System.Text.Json;

namespace MVC05.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly db_Shop4TrainingContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HangHoaController(db_Shop4TrainingContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View(); 
        }

        [Route("")]
        [Route("home/index")]
        public IActionResult Shop()  
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PKIHanghoaId,STenhang,FGianiemyet,SDacdiem,SXuatxu")] TblHanghoa tblHanghoa, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    // Kiểm tra định dạng của tệp tin
                    string fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
                    if (fileExtension == ".png" || fileExtension == ".jpg")
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        await imageFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
                        tblHanghoa.SAnhminhhoa = "/uploads/" + uniqueFileName;

                        _context.Add(tblHanghoa);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Vui lòng tải lên tệp tin định dạng PNG hoặc JPG.";
                        return View(tblHanghoa);
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Hãy nhập hình ảnh của sản phẩm.";
                    return View(tblHanghoa);
                }
            }
            return View(tblHanghoa);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var hanghoa = await _context.TblHanghoas.FindAsync(id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            _context.TblHanghoas.Remove(hanghoa);
            await _context.SaveChangesAsync();
            return Json(hanghoa);
        }

        [HttpPost]
        public IActionResult AddItemToSession(int numberToAdd)
        {
            List<int> items;
            if (HttpContext.Session.Get("items") != null)
            {
                items = JsonSerializer.Deserialize<List<int>>(HttpContext.Session.GetString("items"));
            }
            else
            {
                items = new List<int>();
            }

            items.Add(numberToAdd);
            HttpContext.Session.SetString("items", JsonSerializer.Serialize(items));

            int itemCount = items.Count;

            return Json(new { itemCount });
        }

        [HttpPost]
        public IActionResult RemoveItemFromSession(int numberToRemove)
        {
            List<int> items;
            if (HttpContext.Session.Get("items") != null)
            {
                items = JsonSerializer.Deserialize<List<int>>(HttpContext.Session.GetString("items"));
                if (items.Contains(numberToRemove))
                {
                    items.Remove(numberToRemove);
                    HttpContext.Session.SetString("items", JsonSerializer.Serialize(items));
                }
            }
            int itemCount = 0;

            return RedirectToAction("ActionName", "ControllerName");
        }


        public IActionResult CardList()
        {
            List<int> items = new List<int>();

            if (HttpContext.Session.Get("items") != null)
            {
                items = JsonSerializer.Deserialize<List<int>>(HttpContext.Session.GetString("items"));
            }

            List<TblHanghoa> hanghoasFromDb = new List<TblHanghoa>();

            foreach (var itemId in items)
            {
                var hanghoa = _context.TblHanghoas.FirstOrDefault(x => x.PkIHanghoaId == itemId);
                if (hanghoa != null)
                {
                    hanghoasFromDb.Add(hanghoa);
                }
            }
            return View(hanghoasFromDb);
        }


        [HttpGet]
        public IActionResult Search(string tenHang)
        {
            if (string.IsNullOrEmpty(tenHang))
            {
                var allHangHoas = _context.TblHanghoas.ToList();
                return Json(allHangHoas);
            }

            var result = _context.TblHanghoas
                                .Where(h => h.STenhang.Contains(tenHang))
                                .ToList();
            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var comments = await _context.TblHanghoas.ToListAsync();
            return Json(comments);
        }
    }
}
 