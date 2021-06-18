using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages.Haeuser
{
    public class HaeuserIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public HaeuserIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Haus> Haus { get; set; }
        public async Task OnGet()
        {
            Haus = await _db.Haus.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var Haus = await _db.Haus.FindAsync(Id);
            if (Haus == null)
            {
                return NotFound();
            }
            _db.Haus.Remove(Haus);
            await _db.SaveChangesAsync();

            return RedirectToPage("HaeuserIndex");
        }

        public string PopulateStandortNameBy(int Id)
        {
            var StandortName = from Standort in _db.Standort
                               where Standort.Id == Id
                               select Standort;
            return StandortName.FirstOrDefault().StandortName;
        }
        public string PopulateRaumNameBy(int? Id)
        {
            if (Id == null)
            {
                return "NULL";
            }
            else
            {
                var RaumName = from s in _db.Raum
                               where s.Id == Id
                               select s;
            return RaumName.FirstOrDefault().RaumName;
            }
        }
        public string PopulateStockNameBy(int Id)
        {
            var StockName = from s in _db.Stockwerk
                               where s.Id == Id
                               select s;
            return StockName.FirstOrDefault().StockName;
        }
    }
}
