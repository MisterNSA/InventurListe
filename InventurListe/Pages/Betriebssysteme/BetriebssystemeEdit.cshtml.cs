using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventurListe.Pages.Betriebssysteme
{
    public class BetriebssystemeEditModel : PageModel
    {
        private ApplicationDbContext _db;

        public BetriebssystemeEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Betriebssystem Betriebssystem { get; set; }
        public async Task OnGet(int Id)
        {
            Betriebssystem = await _db.Betriebssystem.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RaumFromDb = await _db.Betriebssystem.FindAsync(Betriebssystem.Id);
                RaumFromDb.Name = Betriebssystem.Name;

                await _db.SaveChangesAsync();

                return RedirectToPage("BetriebssystemeIndex");
            }
            return RedirectToPage();
        }
    }
}
