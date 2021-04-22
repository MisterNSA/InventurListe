using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages.Standorte
{
    public class StandorteIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public StandorteIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Standort> Standort { get; set; }
        public async Task OnGet()
        {
            Standort = await _db.Standort.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var Standort = await _db.Standort.FindAsync(Id);
            if (Standort == null)
            {
                return NotFound();
            }
            _db.Standort.Remove(Standort);
            await _db.SaveChangesAsync();

            return RedirectToPage("StandorteIndex");
        }
    }
}
