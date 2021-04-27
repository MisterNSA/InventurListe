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
        public Gerät Gerät { get; set; }

        public SelectList GeräteTypOptions { get; set; }
        public SelectList HausOptions { get; set; }
        public SelectList BetriebssystemOptions { get; set; }
        public SelectList AbteilungOptions { get; set; }
        public async Task OnGet(string InventurNr)
        {
            Gerät = await _db.Gerät.FindAsync(InventurNr);
            PopulateGeräteTypOptions();
            PopulateHausOptions();
            PopulateBetriebssystemOptions();
            PopulateAbteilungOptions();
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

                return RedirectToPage("GeraeteIndex");
            }
            return RedirectToPage();
        }
        // Auswahllisten
        public void PopulateGeräteTypOptions(object selectedItem = null)
        {
            var GeräteTypQuery = from s in _db.GeräteTyp
                                 orderby s.GerätTyp
                                 select s;
            GeräteTypOptions = new SelectList(GeräteTypQuery.AsNoTracking(), "Id", "GerätTyp", selectedItem);
        }
        public void PopulateHausOptions(object selectedItem = null)
        {
            var HausQuery = from s in _db.Haus
                            orderby s.HausName
                            select s;
            HausOptions = new SelectList(HausQuery.AsNoTracking(), "Id", "HausName", selectedItem);
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
