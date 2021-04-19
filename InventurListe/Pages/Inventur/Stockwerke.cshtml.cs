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
    public class StockwerkeModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public StockwerkeModel(ApplicationDbContext db)
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
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
