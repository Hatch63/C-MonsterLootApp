using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDLootApp.Models;

namespace DDLootApp.Pages.Monsters
{
    public class EditModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public EditModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Monster Monster { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Monster = await _context.Monster.FindAsync(id);

            if (Monster == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var monsterToUpdate = await _context.Monster.FindAsync(id);

            if (await TryUpdateModelAsync<Monster>(
                monsterToUpdate,
                "monster",
                s => s.Name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool MonsterExists(int id)
        {
            return _context.Monster.Any(e => e.ID == id);
        }
    }
}
