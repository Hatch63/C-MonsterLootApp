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
    public class DetailsModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public DetailsModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        public MonsterItem MonsterItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MonsterItem = await _context.MonsterItems
                .Include(m => m.Monster).FirstOrDefaultAsync(m => m.ID == id);

            if (MonsterItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
