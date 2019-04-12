using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DDLootApp.Models;

namespace DDLootApp.Pages.Monsters
{
    public class IndexModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public IndexModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Monster> Monster { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Monster> monsterIQ = from s in _context.Monster
                                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                monsterIQ = monsterIQ.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    monsterIQ = monsterIQ.OrderByDescending(s => s.Name);
                    break;
                default:
                    monsterIQ = monsterIQ.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 10;
            Monster = await PaginatedList<Monster>.CreateAsync(
                monsterIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
