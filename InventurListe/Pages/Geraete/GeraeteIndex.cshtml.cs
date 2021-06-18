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
            var Ger�teTypName = (from Ger�teTyp in _db.Ger�teTyp
                                 where Ger�teTyp.Id == Id
                                 select Ger�teTyp.Ger�tTyp).FirstOrDefault();
            return Ger�teTypName.ToString();
        }
        public string PopulateHausNameBy(int Id)
        {
            var HausQuery = from haus in _db.Haus
                            join Standort in _db.Standort
                                on haus.StandortId equals Standort.Id
                            join Stockwerk in _db.Stockwerk
                                on haus.StockId equals Stockwerk.Id
                            join Raum in _db.Raum
                                on haus.RaumId equals Raum.Id
                            where haus.Id == Id
                            select new
                            {
                                Hausname = Standort.StandortName
                                + " - " + haus.HausName
                                + " - " + Stockwerk.StockName
                                + " - " + Raum.RaumName
                            };
            return HausQuery.FirstOrDefault().Hausname.ToString();
        }
        public string PopulateBetriebssystemNameBy(int Id)
        {
            var BetriebssystemName = (from Betriebssystem in _db.Betriebssystem
                                      where Betriebssystem.Id == Id
                                      select Betriebssystem.Name).FirstOrDefault();
            return BetriebssystemName.ToString();
        }
        public string PopulateAbteilungNameBy(int Id)
        {
            var AbteilungName = (from Abteilung in _db.Abteilung
                                 where Abteilung.Id == Id
                                 select Abteilung.AbteilungName).FirstOrDefault();
            return AbteilungName.ToString();
        }
    }
}
