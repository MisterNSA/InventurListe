using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventurListe.Data;
using InventurListe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InventurListe.Pages.Inventur
{
    public class HäuserModel : PageModel
    {
        public SelectList StandortOptions { get; set; }

        private readonly ApplicationDbContext _db;

        public HäuserModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Haus Haus { get; set; }

        public void PopulateStandortOptions(object selectedItem = null)
        {
            var StandortQuery = from s in _db.Standort
                                orderby s.StandortName
                                select s;

            StandortOptions = new SelectList(StandortQuery.AsNoTracking(), "Id", "StandortName", selectedItem);
            
        }

        public string PopulateStandortNameBy(int Id)
        {
            var StandortName = from s in _db.Standort
                                where s.Id == Id
                                select s.StandortName;

            return StandortName.ToString(); 

        }
        public void OnGet()
        {
            PopulateStandortOptions();
            

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Haus.AddAsync(Haus);
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
