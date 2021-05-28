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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Ger�t Ger�t { get; set; }
        public SelectList Ger�teTypOptions { get; set; }
        public SelectList HausOptions { get; set; }
        public SelectList BetriebssystemOptions { get; set; }
        public SelectList AbteilungOptions { get; set; }

        public void OnGet()
        {
            PopulateGer�teTypOptions();
            PopulateHausOptions();
            PopulateBetriebssystemOptions();
            PopulateAbteilungOptions();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Ger�t.AddAsync(Ger�t);
                await _db.SaveChangesAsync();
                return RedirectToPage("GeraeteIndex");
            }
            else
            {
                return Page();
            }
        }
        // Auswahllisten
        public void PopulateGer�teTypOptions(object selectedItem = null)
        {
            var Ger�teTypQuery = from s in _db.Ger�teTyp
                                orderby s.Ger�tTyp
                                select s;
            Ger�teTypOptions = new SelectList(Ger�teTypQuery.AsNoTracking(), "Id", "Ger�tTyp", selectedItem);
        }
        /*
        public void PopulateHausOptions(object selectedItem = null)
        {
            var HausQuery = from s in _db.Haus
                            orderby s.HausName
                            select s;
            HausOptions = new SelectList(HausQuery.AsNoTracking(), "Id", "HausName", selectedItem);
        }
        */
        public void PopulateHausOptions(object selectedItem = null)
        {
            var HausQuery = from haus in _db.Haus
                            join Standort in _db.Standort
                                on haus.StandortId equals Standort.Id
                            join Stockwerk in _db.Stockwerk 
                                on haus.StockId equals Stockwerk.Id
                            join Raum in _db.Raum
                                on haus.RaumId equals Raum.Id
                            select new
                            {
                                Standort = Standort.StandortName,
                                Haus = haus.HausName,
                                Stock = Stockwerk.StockName,
                                Raum = Raum.RaumName
                            };
            HausOptions = new SelectList(HausQuery.AsNoTracking());
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
