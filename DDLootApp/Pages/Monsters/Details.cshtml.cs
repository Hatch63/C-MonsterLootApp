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
    public class DetailsModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public DetailsModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        public Monster Monster { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Monster = await _context.Monster
                        .Include(s => s.MonsterItems)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == id);

            if (Monster == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
