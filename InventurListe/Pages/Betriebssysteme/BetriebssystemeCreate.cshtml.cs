using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages.Betriebssysteme
{
    public class BetriebssystemeCreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public BetriebssystemeCreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Betriebssystem Betriebssystem { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Betriebssystem.AddAsync(Betriebssystem);
                await _db.SaveChangesAsync();
                return RedirectToPage("BetriebssystemeIndex");
            }
            else
            {
                return Page();
            }
        }
    }
}
