using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Models.Models;
using Shop.Models.ViewModels;
using Shop.Utility;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            

            return View();
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = _db.ApplicationUsers.Include(u => u.Company).FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete([FromBody] string id)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return Json(new { success = false, message = "Lỗi khi xóa người dùng" });
            }

            _db.ApplicationUsers.Remove(user);
            _db.SaveChanges();

            return Json(new { success = true, message = "Đã xóa người dùng thành công" });
        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() {
            List<ApplicationUser> objUserList = _db.ApplicationUsers.Include(u=>u.Company).ToList();

            var userRoles = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in objUserList) {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;

                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

                if(user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }
            return Json(new { dat = objUserList });
        }


        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id) 
        
        {
            // Tìm kiếm ApplicationUser trong cơ sở dữ liệu với id đã chỉ định
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);

            // Kiểm tra nếu người dùng không được tìm thấy
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Lỗi khi khóa/mở khóa" });
            }
            // Kiểm tra xem người dùng có bị khóa không
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }
        
            _db.SaveChanges();
            return Json(new { success = true, message = " Thành công " });
        }

        #endregion
    }
}
