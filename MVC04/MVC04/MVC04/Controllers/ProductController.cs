using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MVC04.DataContext;
using MVC04.Models;
using MVC04.Repository;

namespace MVC04.Controllers
{
    public class ProductController : Controller
    {
        private LtwncContext _context;
        private ProductRepository _productRepository = new ProductRepository();

        public ProductController(LtwncContext context)
        {
            _context = context;
        }

        [Route("")]
        [Route("home/index")]
        public ActionResult Index()
        {
            List<Product> products = _productRepository.GetProducts();
            return View(products);
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(TblProduct model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                bool isProductAdded = _productRepository.AddProduct(model.ProductName, model.ImageURL, model.ProductPrice, model.Description);

                if (isProductAdded)
                {
                    return RedirectToAction("Index", "Home"); // Chuyển hướng về trang chủ sau khi thêm sản phẩm thành công
                }
                else
                {
                    ViewBag.ErrorMessage = "Sản phẩm này đã tồn tại rồi, không thể thêm nữa.";
                    return View();
                }
            }
            return View(model);
        }

    }
}
