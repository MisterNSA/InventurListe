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
    public class AbteilungenModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AbteilungenModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Abteilung Abteilung { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Abteilung.AddAsync(Abteilung);
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
