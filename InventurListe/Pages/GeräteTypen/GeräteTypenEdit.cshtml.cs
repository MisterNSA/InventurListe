using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventurListe.Pages.GeräteTypen
{
    public class GeräteTypenEditModel : PageModel
    {
        private ApplicationDbContext _db;

        public GeräteTypenEditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public GeräteTyp GeräteTyp { get; set; }
        public async Task OnGet(int Id)
        {
            GeräteTyp = await _db.GeräteTyp.FindAsync(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var GeräteTypFromDb = await _db.GeräteTyp.FindAsync(GeräteTyp.Id);
                GeräteTypFromDb.GerätTyp = GeräteTyp.GerätTyp;
                GeräteTypFromDb.Modell = GeräteTyp.Modell;

                await _db.SaveChangesAsync();

                return RedirectToPage("GeräteTypenIndex");
            }
            return RedirectToPage();
        }
    }
}
