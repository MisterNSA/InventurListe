using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace InventurListe.Pages.Inventur
{
    public class StockwerkeIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public StockwerkeIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Stockwerk> Stockwerk { get; set; }
        public async Task OnGet()
        {
            Stockwerk = await _db.Stockwerk.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var Stockwerk = await _db.Stockwerk.FindAsync(Id);
            if (Stockwerk == null)
            {
                return NotFound();
            }
            _db.Stockwerk.Remove(Stockwerk);
            await _db.SaveChangesAsync();

            return RedirectToPage("StockwerkeIndex");
        }
    }
}
