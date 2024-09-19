using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Hannah
{
    public class DetailsModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public DetailsModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

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
    }
}
