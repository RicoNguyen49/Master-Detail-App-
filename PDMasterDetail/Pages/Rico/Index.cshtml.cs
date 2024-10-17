using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Rico
{
    public class IndexModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public IndexModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        public IList<RockClass> RockClass { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string RockType { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "NameDesc" : "";
            TypeSort = sortOrder == "TypeAsc" ? "TypeDesc" : "TypeAsc";

            IQueryable<string> TypeQuery = from r in _context.RockClass
                                           orderby r.Type
                                           select r.Type;

            var resources = from r in _context.RockClass
                            select r;

            if (!string.IsNullOrEmpty(SearchString))
            {
                resources = resources.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(RockType))
            {
                resources = resources.Where(t => t.Type == RockType);
            }
            switch (sortOrder)
            {
                case "NameDesc":
                    resources = resources.OrderByDescending(r => r.Name);
                    break;
                case "TypeDesc":
                    resources = resources.OrderByDescending(r => r.Type);
                    break;
                case "TypeAsc":
                    resources = resources.OrderBy(r => r.Type);
                    break;
                default:
                    resources = resources.OrderBy(r => r.Name);
                    break;
            }

            Types = new SelectList(await TypeQuery.Distinct().ToListAsync());

            RockClass = await resources.ToListAsync();
        }
    }
}
