using EntityFrameworkProject.Data;
using EntityFrameworkProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public  async Task<IActionResult> Index()
        {

            IEnumerable<Category> categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            var name1 = category.Name.ToLower();
            var name2 = _context.Categories.FirstOrDefault(m => m.Name == category.Name).Name.ToLower();

            bool isExist = await _context.Categories.AnyAsync(m => m.Name.Trim().ToLower() == category.Name.Trim().ToLower());


            if (isExist)
            {
                ModelState.AddModelError("Name", "Category already exist");
            }


            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
