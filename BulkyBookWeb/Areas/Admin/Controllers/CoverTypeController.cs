using BulkyBook.DataAccess.Repository.IRepolository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateObj(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Creation successs";
                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id==0 || id==null)
            {
                return NotFound();
            }
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType==null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditObj(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edit success"; 
                return RedirectToAction("Index");
            }
            return View();
        }
        //GET
        public IActionResult Delete(int? id)    
        {
            if (id==0 || id==null)
            {
                return NotFound();
            }
            var coverType = _unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType==null)
            {
                return NotFound();
            }
            return View(coverType);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteObj(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Delete Success";
            return RedirectToAction("Index");


        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypes = _unitOfWork.CoverType.GetAll();
            return View(coverTypes);
        }
    }
}
