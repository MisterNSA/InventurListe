using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages.Stockwerke
{
    public class StockwerkeCreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public StockwerkeCreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Stockwerk Stockwerk { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Stockwerk.AddAsync(Stockwerk);
                await _db.SaveChangesAsync();
                return RedirectToPage("StockwerkeIndex");
            }
            else
            {
                return Page();
            }
        }
    }
}
