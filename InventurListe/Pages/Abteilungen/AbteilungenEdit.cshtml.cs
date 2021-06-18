using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventurListe.Pages.Inventur.Abteilungen
{
    public class AbteilungenEditModel : PageModel
    {
        private ApplicationDbContext _db;

        public AbteilungenEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Abteilung Abteilung { get; set; }
        public async Task OnGet(int Id)
        {
            Abteilung = await _db.Abteilung.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var AbteilungFromDb = await _db.Abteilung.FindAsync(Abteilung.Id);
                AbteilungFromDb.AbteilungName = Abteilung.AbteilungName;

                await _db.SaveChangesAsync();

                return RedirectToPage("AbteilungenIndex");
            }
            return RedirectToPage();
        }
    }
}
