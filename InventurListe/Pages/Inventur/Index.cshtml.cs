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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Ger�t> Ger�t { get; set; }
        public async Task OnGet()
        {
            Ger�t = await _db.Ger�t.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(string InventurNr)
        {
            var Ger�t = await _db.Ger�t.FindAsync(InventurNr);
            if (Ger�t == null)
            {
                return NotFound();
            }
            _db.Ger�t.Remove(Ger�t);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
