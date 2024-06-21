using AppMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [Route("/cac-san-pham/{id?}")]
        public IActionResult Index()
        {
            // /Areas/AreaName/Views/ControllerName/Action.cshtml

            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products); // Areas/ProductManage/Views/Product/Index.cshtml

        }
    }
}