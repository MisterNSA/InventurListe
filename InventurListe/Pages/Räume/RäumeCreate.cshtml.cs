using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages.Räume
{
    public class RäumeCreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public RäumeCreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Raum Raum { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Raum.AddAsync(Raum);
                await _db.SaveChangesAsync();
                return RedirectToPage("RäumeIndex");
            }
            else
            {
                return Page();
            }
        }
    }
}
