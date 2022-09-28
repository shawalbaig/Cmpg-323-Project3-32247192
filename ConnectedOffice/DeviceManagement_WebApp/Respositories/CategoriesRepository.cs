using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq.Expressions;
using DeviceManagement_WebApp.Generic;
using DeviceManagement_WebApp.Interface;





    public class CategoriesController : Controller
    {

        private readonly ConnectedOfficeContext _context;



        public CategoriesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(_context.Category.ToList());

        }



        // GET: Categories/Details/5 
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        // GET: Categories/Create 
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for  
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5 
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", category.CategoryId);
             
            return View(category);
        }

        // POST: Categories/Edit/5 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for  
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 
        //[HttpPost] 
        //[ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit1(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }
            try
            {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.CategoryId))
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

        // GET: Categories/Delete/5 
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5 
        //    [HttpPost, ActionName("Delete")] 
        //    [ValidateAntiForgeryToken] 
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);  
        }
    }
        //    public class Categorieontroller : Controller
        //    {
        //        private readonly ConnectedOfficeContext _context;
        //        //private readonly ICategoriesRepository<Category> categoriesRepository1;

        //        //public CategoriesController(ICategoriesRepository<Category> categoriesRepository)
        //        //{
        //        //    categoriesRepository1 = categoriesRepository;
        //        //}
        //        //public async Task<IActionResult> Index()
        //        //{
        //        //    return View(categoriesRepository1.GetAll());
        //        //}



        //        public CategoriesController(ConnectedOfficeContext context)
        //        {
        //            _context = context;
        //        }

        //        // GET: Categories
        //        public async Task<IActionResult> Index()
        //        {
        //            var connectedOfficeContext = _context.Category.Include(d => d.CategoryDescription).Include(d => d.CategoryName);
        //            return View(await connectedOfficeContext.ToListAsync());
        //        }

        //        public async Task<IActionResult> Index2()
        //        {
        //            return View(await _context.Category.ToListAsync());
        //        }

        //        //GET: Categories/Details/5        //public async Task<IActionResult> Details(Guid? id)
        //        //{
        //        //    CategoriesRepository categoriesRepository = new CategoriesRepository();
        //        //    var results = categoriesRepository.Details((Guid)id);
        //        //    return View(results);
        //        //}

        //        //GET: Categories/Create
        //            public IActionResult Create()
        //        {
        //            return View();
        //        }

        //        // POST: Categories/Create
        //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        //        {
        //            category.CategoryId = Guid.NewGuid();
        //            _context.Add(category);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        // GET: Categories/Edit/5
        //        public async Task<IActionResult> Edit(Guid? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var category = await _context.Category.FindAsync(id);
        //            if (category == null)
        //            {
        //                return NotFound();
        //            }
        //            return View(category);
        //        }

        //        // POST: Categories/Edit/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        //        {
        //            if (id != category.CategoryId)
        //            {
        //                return NotFound();
        //            }
        //            try
        //            {
        //                _context.Update(category);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!CategoryExists(category.CategoryId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }

        //        // GET: Categories/Delete/5
        //        public async Task<IActionResult> Delete(Guid? id)
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var category = await _context.Category
        //                .FirstOrDefaultAsync(m => m.CategoryId == id);
        //            if (category == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(category);
        //        }

        //        // POST: Categories/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(Guid id)
        //        {
        //            var category = await _context.Category.FindAsync(id);
        //            _context.Category.Remove(category);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool CategoryExists(Guid id)
        //        {
        //            return _context.Category.Any(e => e.CategoryId == id);
        //        }


        //    }
        //}
    




    //private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
    //public CategoriesRepository(ConnectedOfficeContext context): base(context)
    //    {

    //    }
    //public Category GetMostrecentCategory()
    //{
    //    return _context.Category.OrderByDescending(Category => Category.DateCreated).FirstOrDefault();
    //}
    // ALL THE METHODS 
    // get all method 
    //public List<Category> Getall()
    //    {
    //        return _context.Category.ToList();
    //    }

    //    public async Task<IActionResult> Details(Guid? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var category = await _context.Category
    //            .FirstOrDefaultAsync(m => m.CategoryId == id);
    //        if (category == null)
    //        {
    //            return NotFound();
    //        }

    //        return (IActionResult)category.CategoryName.ToList();

    //    }

    //    private IActionResult NotFound()
    //    {
    //        throw new NotImplementedException();
    //    }
