using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Utility;
using System.Diagnostics;
using System.Security.Claims;
using WebShop.Models;

namespace WebShop.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitofwork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitiofwork)
        {
            _logger = logger;
            _unitofwork = unitiofwork;

        }



        public IActionResult Index(string searchTerm, int? categoryId)
        {
            IEnumerable<Product> productList;

            if (!string.IsNullOrEmpty(searchTerm))
            {

                productList = _unitofwork.Product.GetAll(filter: p => (p.Title.ToLower().Contains(searchTerm.ToLower()) ||p.Description.ToLower().Contains(searchTerm.ToLower())) &&(!categoryId.HasValue || p.CategoryId == categoryId.Value),includeProperties: "Category,ProductImages"  );
            }
            else if (categoryId.HasValue)
            {
                
                productList = _unitofwork.Product.GetAll(
                    filter: p => p.CategoryId == categoryId.Value,
                    includeProperties: "Category,ProductImages"
                );
            }
            else
            {
                
                productList = _unitofwork.Product.GetAll(includeProperties: "Category,ProductImages");
            }

            var groupedProducts = productList.GroupBy(p => p.Category).ToList();

            return View(groupedProducts);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitofwork.Product.Get(u => u.Id == productId, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitofwork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);

            if(cartFromDb != null)
            {
                cartFromDb.Count += shoppingCart.Count;
                _unitofwork.ShoppingCart.Update(cartFromDb);
                _unitofwork.Save();

            }
            else
            {
                _unitofwork.ShoppingCart.Add(shoppingCart);
                _unitofwork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart, _unitofwork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }

            TempData["success"] = "Đã thêm vào giỏ hàng!";

            return  RedirectToAction(nameof(Home_new));
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

        public IActionResult Home_new(int? categoryId)
        {
            IEnumerable<Product> productList;

            if (categoryId.HasValue)
            {
                // Display products from a specific category
                productList = _unitofwork.Product.GetAll(
                    filter: p => p.CategoryId == categoryId.Value,
                    includeProperties: "Category,ProductImages"
                );
            }
            else
            {
                // Display all products if no category is specified
                productList = _unitofwork.Product.GetAll(includeProperties: "Category,ProductImages");
            }

            var groupedProducts = productList.GroupBy(p => p.Category).ToList();

            return View(groupedProducts);
        }


    }
}