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
    public class StandorteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public StandorteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Standort Standort { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Standort.AddAsync(Standort);
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
