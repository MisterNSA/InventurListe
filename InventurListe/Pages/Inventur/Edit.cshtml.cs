using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventurListe.Pages.Inventur
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Ger�t Ger�t { get; set; }
        public async Task OnGet(string InventurNr)
        {
            Ger�t = await _db.Ger�t.FindAsync(InventurNr);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var Ger�tFromDb = await _db.Ger�t.FindAsync(Ger�t.InventurNr);
                Ger�tFromDb.Ger�teTypId = Ger�t.Ger�teTypId;
                Ger�tFromDb.HausId = Ger�t.HausId;
                Ger�tFromDb.MAC = Ger�t.MAC;
                Ger�tFromDb.IP = Ger�t.IP;
                Ger�tFromDb.Name = Ger�t.Name;
                Ger�tFromDb.BetriebssystemId = Ger�t.BetriebssystemId;
                Ger�tFromDb.VianovaNr = Ger�t.VianovaNr;
                Ger�tFromDb.AbteilungId = Ger�t.AbteilungId;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
