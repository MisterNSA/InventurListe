using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages
{
    public class GeräteTypenIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public GeräteTypenIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<GeräteTyp> GeräteTyp { get; set; }
        public async Task OnGet()
        {
            GeräteTyp = await _db.GeräteTyp.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var GeräteTyp = await _db.GeräteTyp.FindAsync(Id);
            if (GeräteTyp == null)
            {
                return NotFound();
            }
            _db.GeräteTyp.Remove(GeräteTyp);
            await _db.SaveChangesAsync();

            return RedirectToPage("GeräteTypenIndex");
        }
    }
}
