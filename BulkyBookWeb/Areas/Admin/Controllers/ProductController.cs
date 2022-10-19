using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepolository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }),
                CoverTypeList = _unitOfWork.CoverType.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() })
            };
            if (id == null || id == 0)
            {
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(productVM);

            }
            else
            {

            }
            return View(productVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Upsert(ProductVM obj, IFormFile file)
        {

        }

    }
}
