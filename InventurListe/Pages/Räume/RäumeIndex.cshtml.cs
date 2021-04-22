using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages.Inventur
{
    public class RäumeIndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public RäumeIndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Raum> Raum { get; set; }
        public async Task OnGet()
        {
            Raum = await _db.Raum.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var Raum = await _db.Raum.FindAsync(Id);
            if (Raum == null)
            {
                return NotFound();
            }
            _db.Raum.Remove(Raum);
            await _db.SaveChangesAsync();

            return RedirectToPage("RäumeIndex");
        }
    }
}
