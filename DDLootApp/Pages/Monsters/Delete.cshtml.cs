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
    public class DeleteModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public DeleteModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Monster Monster { get; set; }
        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Monster = await _context.Monster
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Monster == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (monster == null)
            {
                return NotFound();
            }

            try
            {
                _context.Monster.Remove(monster);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
