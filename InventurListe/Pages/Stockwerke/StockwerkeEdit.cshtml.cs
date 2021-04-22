using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventurListe.Pages.Stockwerke
{
    public class StockwerkeEditModel : PageModel
    {
        private ApplicationDbContext _db;

        public StockwerkeEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Stockwerk Stockwerk { get; set; }
        public async Task OnGet(int Id)
        {
            Stockwerk = await _db.Stockwerk.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var StockwerkFromDb = await _db.Stockwerk.FindAsync(Stockwerk.Id);
                StockwerkFromDb.StockName = Stockwerk.StockName;

                await _db.SaveChangesAsync();

                return RedirectToPage("StockwerkeIndex");
            }
            return RedirectToPage();
        }
    }
}
