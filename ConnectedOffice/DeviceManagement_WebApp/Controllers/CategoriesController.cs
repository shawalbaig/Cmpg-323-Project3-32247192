
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Generic;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Repositories;

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesRepository _categoryRepository = new CategoriesRepository();

        //GET: /Categories 
        public async Task<IActionResult> Index()
        {

            //var result = _categoryRepository.GetAll(); 
            //return View(result); 
            return View(_categoryRepository.GetAll());
        }



        //2 
        // GET: /Categories/Details/5 
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryRepository.GetById(id);
            //var category = await _context.Category 
            //    .FirstOrDefaultAsync(m => m.CategoryId == id); 
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        //3 
        // GET: /Categories/Create 
        public IActionResult Create()
        {
            return View();
        }

        //4 
        // POST: Categories/Create 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for  
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            //_context.Add(category); 
            _categoryRepository.Add(category);
            // await _context.SaveChangesAsync(); 
            _categoryRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        //5 
        // GET: Categories/Edit/5 
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var category = await _context.Category.FindAsync(id); 
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //6 
        // POST: Categories/Edit/5 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for  
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }
            try
            {
                //_context.Update(category); 
                //await _context.SaveChangesAsync(); 
                //_categoryRepository.Entry(category).State = EntityState.Modified; 

                _categoryRepository.Update(category);
                _categoryRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != (category.CategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        //7 
        //GET: Categories/Delete/5 
        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var category = await _context.Category
            //  .FirstOrDefaultAsync(m => m.CategoryId == id);
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
    }
}

    
    
       
    

    
    




