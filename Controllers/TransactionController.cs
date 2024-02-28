using ExpenseTracker.Models;
using ExpenseTracker.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;


namespace ExpenseTracker.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;
        Helpers helper = new Helpers();

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transactions.Include(t => t.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateCategories();
            if (id == 0)
                return View(new Transaction());
            else
                return View(_context.Transactions.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,CategoryId,Amount,Note,Date,File")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                List<Category> categoriesList = _context.Categories.ToList();
                if (transaction.TransactionId == 0)
                {                    
                    if (transaction.File != null)
                    {
                        //can use some refactoring, there's no need to repeat code
                        var categoryName = categoriesList.Where(c => c.CategoryId == transaction.CategoryId)
                                                        .Select(c => c.Title)
                                                        .FirstOrDefault();
                        helper.createFolderForInvoice(categoryName);
                        string folderPath = helper.folderPath(categoryName);
                        helper.importFile(folderPath, transaction.File);
                    }
                    _context.Add(transaction);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    if (transaction.File != null)
                    {
                        //can use some refactoring, there's no need to repeat code
                        var categoryName = categoriesList.Where(c => c.CategoryId == transaction.CategoryId)
                                                       .Select(c => c.Title)
                                                       .FirstOrDefault();
                        helper.createFolderForInvoice(categoryName);
                        string folderPath = helper.folderPath(categoryName);
                        helper.importFile(folderPath, transaction.File);
                    }
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateCategories();
            return View(transaction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
            }
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [NonAction]
        public void PopulateCategories()
        {
            var CategoryCollection = _context.Categories.ToList();
            Category DefaultCategory = new Category() { CategoryId = 0, Title = "Choose a Category" };
            CategoryCollection.Insert(0, DefaultCategory);
            ViewBag.Categories = CategoryCollection;
        }
    }
}
