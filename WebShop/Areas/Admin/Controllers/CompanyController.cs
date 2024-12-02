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

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public CompanyController(IUnitOfWork unitiofwork)
        {
            _unitofwork = unitiofwork;
        }
        public IActionResult Index(string searchString)
        {
            List<Company> objCompanyList = _unitofwork.Company.GetAll().ToList();

            //Demo sreach
            var CompanySR = from m in _unitofwork.Company.GetAll() select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                CompanySR = CompanySR.Where(s => s.Name!.Contains(searchString));
            }
            objCompanyList = CompanySR.ToList();
            //Demo sreach category



            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company CompanyObj = _unitofwork.Company.Get(u => u.Id == id);
                return View(CompanyObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {

                if (CompanyObj.Id == 0)
                {
                    _unitofwork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitofwork.Company.Update(CompanyObj);
                }

                _unitofwork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {

                return View(CompanyObj);
            }
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Company? CompanyFromDb = _unitofwork.Company.Get(u => u.Id == id);

            if (CompanyFromDb == null)
            {
                return NotFound();
            }
            return View(CompanyFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Company? obj = _unitofwork.Company.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }

            _unitofwork.Company.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = " Đã xóa danh mục thành công";

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() {
            List<Company> objCompanyList = _unitofwork.Company.GetAll().ToList();
            return Json(new { dat = objCompanyList });
        }

        #endregion
    }
}
