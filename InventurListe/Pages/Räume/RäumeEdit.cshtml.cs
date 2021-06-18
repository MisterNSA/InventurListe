using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventurListe.Pages.Räume
{
    public class RäumeEditModel : PageModel
    {
        private ApplicationDbContext _db;

        public RäumeEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Raum Raum { get; set; }
        public async Task OnGet(int Id)
        {
            Raum = await _db.Raum.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var RaumFromDb = await _db.Raum.FindAsync(Raum.Id);
                RaumFromDb.RaumName = Raum.RaumName;

                await _db.SaveChangesAsync();

                return RedirectToPage("RäumeIndex");
            }
            return RedirectToPage();
        }
    }
}
