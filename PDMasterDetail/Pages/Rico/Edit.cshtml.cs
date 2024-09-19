using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Rico
{
    public class EditModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public EditModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RockClass RockClass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rockclass =  await _context.RockClass.FirstOrDefaultAsync(m => m.Id == id);
            if (rockclass == null)
            {
                return NotFound();
            }
            RockClass = rockclass;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RockClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RockClassExists(RockClass.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RockClassExists(int id)
        {
            return _context.RockClass.Any(e => e.Id == id);
        }
    }
}
