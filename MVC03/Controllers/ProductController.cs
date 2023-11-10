using Microsoft.AspNetCore.Mvc;
using MVC03.Models;

namespace MVC03.Controllers
{
    public class ProductController : Controller
    {
        [Route("")]
        [Route("home/index")]
        public IActionResult Index()
        {
            var products = ProductModel.GetProducts();

            return View(products);
        }

         public IActionResult ProductDetail(int id)
        {
            var product = ProductModel.GetProducts().FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

    }
}
