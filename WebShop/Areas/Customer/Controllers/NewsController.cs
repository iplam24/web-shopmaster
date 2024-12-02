using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using WebShop.Models;

namespace WebShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class NewsController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public NewsController(IUnitOfWork unitiofwork)
        {
            _unitofwork = unitiofwork;
        }
        public IActionResult Index()
        {
            List<News> objNewsList = _unitofwork.News.GetAll().ToList();
            return View(objNewsList);
        }
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            News news = _unitofwork.News.Get(u => u.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Thanks()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(News obj)
        {

            if (ModelState.IsValid)
            {
                _unitofwork.News.Add(obj);
                _unitofwork.Save();
                TempData["success"] = " Gửi yêu cầu thành công";
                return RedirectToAction("Thanks");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            News? NewsFromDb = _unitofwork.News.Get(u => u.Id == id);
            //Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? CategoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();


            if (NewsFromDb == null)
            {
                return NotFound();
            }
            return View(NewsFromDb);
        }

        [HttpPost]
        public IActionResult Edit(News obj)
        {
            if (obj.Name == obj.Nummber.ToString())
            {
                ModelState.AddModelError("name", "Display Order không thể giống Name");
            }

            if (ModelState.IsValid)
            {
                _unitofwork.News.Update(obj);
                _unitofwork.Save();
                TempData["success"] = " Cập nhật danh mục thành công";

                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            News? NewsFromDb = _unitofwork.News.Get(u => u.Id == id);

            if (NewsFromDb == null)
            {
                return NotFound();
            }
            return View(NewsFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            News? obj = _unitofwork.News.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }

            _unitofwork.News.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = " Đã xóa danh mục thành công";

            return RedirectToAction("Index");
        }


        //Trang chủ
        public IActionResult Home_one()
        {
            return View();
        }

        //Gioithieu
        public IActionResult Gioi_thieu()
        {
            return View();
        }
        public IActionResult Huong_dan_BaoQuan()
        {
            return View();
        }
        public IActionResult Huong_dan_Muabanh()
        {
            return View();
        }
        public IActionResult Huong_dan_ThanhToan()
        {
            return View();
        }
        public IActionResult Huong_dan_KHDN()
        {
            return View();
        }

        public IActionResult Chinh_Sach_BaoMat()
        {
            return View();
        }

        public IActionResult Chinh_Sach_GiaoHang()
        {
            return View();
        }


        public IActionResult Chinh_Sach_XuLyKN()
        {
            return View();
        }
        public IActionResult Chinh_Sach_DoiTra()
        {
            return View();
        }

    }

}
