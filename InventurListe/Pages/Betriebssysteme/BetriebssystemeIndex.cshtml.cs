using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages
{
    public class BetriebssystemIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public BetriebssystemIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Betriebssystem> Betriebssystem { get; set; }
        public async Task OnGet()
        {
            Betriebssystem = await _db.Betriebssystem.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var Betriebssystem = await _db.Betriebssystem.FindAsync(Id);
            if (Betriebssystem == null)
            {
                return NotFound();
            }
            _db.Betriebssystem.Remove(Betriebssystem);
            await _db.SaveChangesAsync();

            return RedirectToPage("BetriebssystemeIndex");
        }
    }
}
