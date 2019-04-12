using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DDLootApp.Models;

namespace DDLootApp.Pages.MonsterItems
{
    public class IndexModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public IndexModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        public IList<MonsterItem> MonsterItem { get;set; }

        public async Task OnGetAsync()
        {
            MonsterItem = await _context.MonsterItems
                .Include(m => m.Monster).ToListAsync();
        }
    }
}
