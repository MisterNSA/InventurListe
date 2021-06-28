using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public SelectList Ger�teTypOptions { get; set; }
        public SelectList HausOptions { get; set; }
        public SelectList BetriebssystemOptions { get; set; }
        public SelectList AbteilungOptions { get; set; }
        public async Task OnGet(string InventurNr)
        {
            Ger�t = await _db.Ger�t.FindAsync(InventurNr);
            PopulateGer�teTypOptions();
            PopulateHausOptions();
            PopulateBetriebssystemOptions();
            PopulateAbteilungOptions();
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

                return RedirectToPage("GeraeteIndex");
            }
            return RedirectToPage();
        }
        // Auswahllisten
        public void PopulateGer�teTypOptions(object selectedItem = null)
        {
            var Ger�teTypQuery = from s in _db.Ger�teTyp
                                 orderby s.Ger�tTyp
                                 select new
                                 {
                                     gid = s.Id,
                                     gbeschreibung = s.Ger�tTyp + " - " + s.Modell
                                 };
            Ger�teTypOptions = new SelectList(Ger�teTypQuery.AsNoTracking(), "gid", "gbeschreibung", selectedItem);
        }
        public void PopulateHausOptions(object selectedItem = null)
        {
            var HausQuery = from haus in _db.Haus
                            join Standort in _db.Standort
                                on haus.StandortId equals Standort.Id
                            join Stockwerk in _db.Stockwerk
                                on haus.StockId equals Stockwerk.Id
                            join Raum in _db.Raum
                                on haus.RaumId equals Raum.Id
                            orderby Standort.StandortName, haus.HausName, Stockwerk.StockName, Raum.RaumName
                            select new
                            {
                                hid = haus.Id,
                                hbeschreibung = Standort.StandortName + " - " + haus.HausName + " - " + Stockwerk.StockName + " - " + Raum.RaumName
                            };
            HausOptions = new SelectList(HausQuery.AsNoTracking(), "hid", "hbeschreibung", selectedItem);
        }

        public void PopulateBetriebssystemOptions(object selectedItem = null)
        {
            var BetriebssystemQuery = from s in _db.Betriebssystem
                                      orderby s.Name
                                      select s;
            BetriebssystemOptions = new SelectList(BetriebssystemQuery.AsNoTracking(), "Id", "Name", selectedItem);
        }
        public void PopulateAbteilungOptions(object selectedItem = null)
        {
            var AbteilungQuery = from s in _db.Abteilung
                                 orderby s.AbteilungName
                                 select s;
            AbteilungOptions = new SelectList(AbteilungQuery.AsNoTracking(), "Id", "AbteilungName", selectedItem);
        }
    }
}
