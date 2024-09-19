using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Hannah
{
    public class CreateModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public CreateModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RockClass RockClass { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RockClass.Add(RockClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
