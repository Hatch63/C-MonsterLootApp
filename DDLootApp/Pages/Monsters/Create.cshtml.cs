using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DDLootApp.Models;

namespace DDLootApp.Pages.Monsters
{
    public class CreateModel : PageModel
    {
        private readonly DDLootApp.Models.LootContext _context;

        public CreateModel(DDLootApp.Models.LootContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Monster Monster { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyMonster = new Monster();

            if (await TryUpdateModelAsync<Monster>(
                emptyMonster,
                "monster",   // Prefix for form value.
                s => s.Name))
            {
                _context.Monster.Add(emptyMonster);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}