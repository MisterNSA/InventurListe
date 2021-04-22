using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventurListe.Pages.Standorte
{
    public class StandorteEditModel : PageModel
    {
        private ApplicationDbContext _db;

        public StandorteEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Standort Standort { get; set; }
        public async Task OnGet(int Id)
        {
            Standort = await _db.Standort.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var StandortFromDb = await _db.Standort.FindAsync(Standort.Id);
                StandortFromDb.StandortName = Standort.StandortName;

                await _db.SaveChangesAsync();

                return RedirectToPage("StandorteIndex");
            }
            return RedirectToPage();
        }
    }
}
