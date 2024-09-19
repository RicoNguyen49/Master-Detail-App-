using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Rico
{
    public class DeleteModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public DeleteModel(PDMasterDetail.Data.PDMasterDetailContext context)
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

            var rockclass = await _context.RockClass.FirstOrDefaultAsync(m => m.Id == id);

            if (rockclass == null)
            {
                return NotFound();
            }
            else
            {
                RockClass = rockclass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rockclass = await _context.RockClass.FindAsync(id);
            if (rockclass != null)
            {
                RockClass = rockclass;
                _context.RockClass.Remove(RockClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
