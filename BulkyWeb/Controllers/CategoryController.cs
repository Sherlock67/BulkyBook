using Bulky.DataAccess;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository.cs;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.CategoryName == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cant match to the category name");
            }
            if (category.CategoryName!=null && category.CategoryName.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["success"] = "Category Created Succesfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
           
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(u => u.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                TempData["success"] = "Category Edited Succesfully";
                _categoryRepository.Save();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepository.Get(u => u.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _categoryRepository.Get(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepository.Remove(obj);
            _categoryRepository.Save();
            TempData["success"] = "Category Deleted Succesfully";
            return RedirectToAction("Index");
        }
    }
}
