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

            return RedirectToPage("GeraeteIndex");
        }

        public string PopulateGer�teTypNameBy(int Id)
        {
            // WIP Alle wichtigen Daten zusammenf�hren
            var Ger�teTypName = from Ger�teTyp in _db.Ger�teTyp
                           where Ger�teTyp.Id == Id
                           select Ger�teTyp.Ger�tTyp;
            return Ger�teTypName.ToString();
        }
        public string PopulateHausNameBy(int Id)
        {
            // WIP Alle wichtigen Daten zusammenf�hren
            var HausName = from Haus in _db.Haus
                               where Haus.Id == Id
                               select Haus.HausName;
            return HausName.ToString();
        }
        public string PopulateBetriebssystemNameBy(int Id)
        {
            var BetriebssystemName = from Betriebssystem in _db.Betriebssystem
                           where Betriebssystem.Id == Id
                           select Betriebssystem.Name;
            return BetriebssystemName.ToString();
        }
        public string PopulateAbteilungNameBy(int Id)
        {
            var AbteilungName = from Abteilung in _db.Abteilung
                            where Abteilung.Id == Id
                            select Abteilung.AbteilungName;
            return AbteilungName.ToString();
        }
    }
}
