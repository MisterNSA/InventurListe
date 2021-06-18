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
    public class AbteilungenIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AbteilungenIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Abteilung> Abteilung { get; set; }
        public async Task OnGet()
        {
            Abteilung = await _db.Abteilung.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var Abteilung = await _db.Abteilung.FindAsync(Id);
            if (Abteilung == null)
            {
                return NotFound();
            }
            _db.Abteilung.Remove(Abteilung);
            await _db.SaveChangesAsync();

            return RedirectToPage("AbteilungenIndex");
        }
    }
}
