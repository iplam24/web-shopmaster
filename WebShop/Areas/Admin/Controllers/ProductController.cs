using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Models.ViewModels;
using Shop.Utility;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]


    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitiofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfwork = unitiofwork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string searchString, string category)
        {
            // Lấy danh sách các danh mục
            ViewBag.Categories = _unitOfwork.Category.GetAll().ToList();

            // Lấy tất cả sản phẩm với thông tin danh mục
            List<Product> objProductList = _unitOfwork.Product.GetAll(includeProperties: "Category").ToList();

            // Tìm kiếm theo tiêu đề nếu có chuỗi tìm kiếm
            if (!String.IsNullOrEmpty(searchString))
            {
                objProductList = objProductList
                    .Where(s => s.Title.ToLower().Contains(searchString.ToLower()))
                    .ToList();
            }

            // Tìm kiếm theo danh mục nếu có danh mục được chọn
            if (!String.IsNullOrEmpty(category))
            {
                objProductList = objProductList
                    .Where(p => p.Category.Name.ToLower() == category.ToLower())
                    .ToList();
            }

            return View(objProductList);
        }


        public IActionResult Upsert(int? id)
        { 

            ProductVM productVM = new()
            {
                CategoryList = _unitOfwork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
           if(id == null || id ==0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = _unitOfwork.Product.Get(u=>u.Id == id, includeProperties:"ProductImages");
                return View(productVM);

            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                if (productVM.Product.Id == 0)
                {
                    _unitOfwork.Product.Add(productVM.Product);
                }
                else
                {
                    _unitOfwork.Product.Update(productVM.Product);
                }

                _unitOfwork.Save();


                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {

                    foreach (IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = @"images\products\product-" + productVM.Product.Id;
                        string finalPath = Path.Combine(wwwRootPath, productPath);

                        if (!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        ProductImage productImage = new()
                        {
                            ImageUrl = @"\" + productPath + @"\" + fileName,
                            ProductId = productVM.Product.Id,
                        };

                        if (productVM.Product.ProductImages == null)
                            productVM.Product.ProductImages = new List<ProductImage>();

                        productVM.Product.ProductImages.Add(productImage);

                    }

                    _unitOfwork.Product.Update(productVM.Product);
                    _unitOfwork.Save();




                }


                TempData["success"] = "Câp nhật thành công";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfwork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfwork.ProductImage.Get(u => u.Id == imageId);
            int productId = imageToBeDeleted.ProductId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath =
                                   Path.Combine(_webHostEnvironment.WebRootPath,
                                   imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfwork.ProductImage.Remove(imageToBeDeleted);
                _unitOfwork.Save();

                TempData["success"] = "Đã xóa danh mục thành công";
            }

            return RedirectToAction(nameof(Upsert), new { id = productId });
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _unitOfwork.Product.Get(u => u.Id == id);

            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfwork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }

            _unitOfwork.Product.Remove(obj);
            _unitOfwork.Save();
            TempData["success"] = " Đã xóa danh mục thành công";

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() {
            List<Product> objProductList = _unitOfwork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { dat = objProductList });
        }

        #endregion
    }
}
