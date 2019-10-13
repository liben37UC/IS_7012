using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;

namespace FinalProject.Pages.Contractors
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public CreateModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BusinessID"] = new SelectList(_context.Business, "ID", "BusinessName");
        ViewData["ProjectID"] = new SelectList(_context.Set<Project>(), "ID", "ProjectName");
            return Page();
        }

        [BindProperty]
        public Contractor Contractor { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contractor.Add(Contractor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}