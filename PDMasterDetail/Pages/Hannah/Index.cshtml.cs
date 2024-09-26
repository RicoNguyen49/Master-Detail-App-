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

namespace PDMasterDetail.Pages.Hannah
{
    public class IndexModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public IndexModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }
        public IList<RockClass> Rock { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Type { get; set; }
        [BindProperty(SupportsGet = true)]
        public string RockType { get; set; }
        public string NameSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NameSort = sortOrder;

            IQueryable<string> typeQuery = from m in _context.RockClass
                                            orderby m.Type
                                            select m.Type;

            var name = from m in _context.RockClass
                            select m;
            var hardness = from m in _context.RockClass
                       select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                name = name.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(RockType))
            {
                name = name.Where(x => x.Type == RockType);
            }
            if (NameSort == "desc")
            {
                name = name.OrderByDescending(m => m.Name);
            }
            else
            {
                name = name.OrderBy(m => m.Name);
            }
            Type = new SelectList(await typeQuery.Distinct().ToListAsync());
            Rock = await name.ToListAsync();
        }
    }
}
