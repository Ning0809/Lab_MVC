using Lab_MVC.Models;
using Lab_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productList = _service.GetProductList();
            var productIndexViewModel = new ProductIndexViewModel
            {
                ProductList = productList
            };
            
            return View(productIndexViewModel);
        }

        
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var product = _service.GetProduct(id);
            
            return View(product);
        }
        
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult CreateProduct(ProductCreateViewModel request)
        {
            if (string.IsNullOrEmpty(request.Product.Name))
            {
                return RedirectToAction("Error", "Home");
            }

            if (!_service.CreateProduct(request.Product))
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction("Index", "Product");
        }

    }

}
