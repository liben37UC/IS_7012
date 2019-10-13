using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Contractors
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public EditModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contractor Contractor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contractor = await _context.Contractor
                .Include(c => c.Business)
                .Include(c => c.Project).FirstOrDefaultAsync(m => m.ID == id);

            if (Contractor == null)
            {
                return NotFound();
            }
           ViewData["BusinessID"] = new SelectList(_context.Business, "ID", "BusinessCountry");
           ViewData["ProjectID"] = new SelectList(_context.Set<Project>(), "ID", "ProjectName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contractor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractorExists(Contractor.ID))
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

        private bool ContractorExists(int id)
        {
            return _context.Contractor.Any(e => e.ID == id);
        }
    }
}
