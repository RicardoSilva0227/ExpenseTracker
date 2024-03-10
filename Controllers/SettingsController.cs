using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //ToDo: change from hardcoded to dynamic when possible
        public async Task<IActionResult> Index(int id)
        {
            PopulateCurrencies();
            if (id == 0)
                return View(new Models.Settings());
            else
                return View(_context.Settings.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSettings([Bind("SettingsId,InvoicesPath")] Models.Settings settings)
        {
            if (ModelState.IsValid)
            {
                if (settings.SettingsId == 0)
                    _context.Add(settings);
                else
                    _context.Update(settings);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private void PopulateCurrencies()
        {
            var CurrencyCollection = _context.Currency.ToList();
            Currency DefaultCurrency = new Currency() { CurrencyId = 0, CurrencyName = "Choose a Currency." };
            CurrencyCollection.Insert(0, DefaultCurrency);
            ViewBag.Currencies = CurrencyCollection;
        }
    }
}
