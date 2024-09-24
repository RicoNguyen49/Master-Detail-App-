using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Cayce
{
    public class IndexModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public IndexModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        public IList<RockClass> RockClass { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> rockQuery = from r in _context.RockClass
                                            orderby r.Type
                                            select r.Type;
            var rocks = from r in _context.RockClass
                         select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                rocks = rocks.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(RockType))
            {
                rocks = rocks.Where(x => x.Type == RockType);
            }
            Type = new SelectList(await rockQuery.Distinct().ToListAsync());
            RockClass = await rocks.ToListAsync();
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RockType { get; set; }
    }
}
