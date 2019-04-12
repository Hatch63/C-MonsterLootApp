using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DDLootApp.Models;

namespace DDLootApp.Pages.MonsterItems
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
        ViewData["MonsterID"] = new SelectList(_context.Monster, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public MonsterItem MonsterItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MonsterItems.Add(MonsterItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}