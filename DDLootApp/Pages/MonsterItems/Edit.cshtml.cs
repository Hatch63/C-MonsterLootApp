using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DDLootApp.Models;

namespace DDLootApp.Pages.MonsterItems
{
    public class EditModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public EditModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["MonsterID"] = new SelectList(_context.Monster, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MonsterItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonsterItemExists(MonsterItem.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MonsterItemExists(int id)
        {
            return _context.MonsterItems.Any(e => e.ID == id);
        }
    }
}
