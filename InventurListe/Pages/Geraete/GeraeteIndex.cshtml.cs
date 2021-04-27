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

        public IEnumerable<Gerät> Gerät { get; set; }
        public async Task OnGet()
        {
            Gerät = await _db.Gerät.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(string InventurNr)
        {
            var Gerät = await _db.Gerät.FindAsync(InventurNr);
            if (Gerät == null)
            {
                return NotFound();
            }
            _db.Gerät.Remove(Gerät);
            await _db.SaveChangesAsync();

            return RedirectToPage("GeraeteIndex");
        }

        public string PopulateGeräteTypNameBy(int Id)
        {
            // WIP Alle wichtigen Daten zusammenführen
            var GeräteTypName = from GeräteTyp in _db.GeräteTyp
                           where GeräteTyp.Id == Id
                           select GeräteTyp.GerätTyp;
            return GeräteTypName.ToString();
        }
        public string PopulateHausNameBy(int Id)
        {
            // WIP Alle wichtigen Daten zusammenführen
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
