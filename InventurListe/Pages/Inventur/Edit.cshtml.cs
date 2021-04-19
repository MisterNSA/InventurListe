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
        public Gerät Gerät { get; set; }
        public async Task OnGet(string InventurNr)
        {
            Gerät = await _db.Gerät.FindAsync(InventurNr);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var GerätFromDb = await _db.Gerät.FindAsync(Gerät.InventurNr);
                GerätFromDb.GeräteTypId = Gerät.GeräteTypId;
                GerätFromDb.HausId = Gerät.HausId;
                GerätFromDb.MAC = Gerät.MAC;
                GerätFromDb.IP = Gerät.IP;
                GerätFromDb.Name = Gerät.Name;
                GerätFromDb.BetriebssystemId = Gerät.BetriebssystemId;
                GerätFromDb.VianovaNr = Gerät.VianovaNr;
                GerätFromDb.AbteilungId = Gerät.AbteilungId;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
