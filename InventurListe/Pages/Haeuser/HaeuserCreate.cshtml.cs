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


namespace InventurListe.Pages.Haeuser
{
    public class HaeuserCreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public HaeuserCreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Haus Haus { get; set; }
        public SelectList StandortOptions { get; set; }
        public SelectList RaumOptions { get; set; }
        public SelectList StockOptions { get; set; }

        public void OnGet()
        {
            /*
             */
            PopulateStandortOptions();
            PopulateRaumOptions();
            PopulateStockOptions();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Haus.AddAsync(Haus);
                await _db.SaveChangesAsync();
                return RedirectToPage("RaeumeIndex");
            }
            else
            {
                return Page();
            }
        }
        // Auswahllisten
        public void PopulateStandortOptions(object selectedItem = null)
        {
            var StandortQuery = from s in _db.Standort
                                orderby s.StandortName
                                select s;
            StandortOptions = new SelectList(StandortQuery.AsNoTracking(), "Id", "StandortName", selectedItem);
        }
        public void PopulateRaumOptions(object selectedItem = null)
        {
            var RaumQuery = from s in _db.Raum
                                orderby s.RaumName
                                select s;
            RaumOptions = new SelectList(RaumQuery.AsNoTracking(), "Id", "RaumName", selectedItem);
        }

        public void PopulateStockOptions(object selectedItem = null)
        {
            var StockQuery = from s in _db.Stockwerk
                            orderby s.StockName
                            select s;
            StockOptions = new SelectList(StockQuery.AsNoTracking(), "Id", "StockName", selectedItem);
        }
    }
}
