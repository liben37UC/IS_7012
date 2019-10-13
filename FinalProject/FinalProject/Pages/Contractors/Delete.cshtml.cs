using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Contractors
{
    public class DeleteModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public DeleteModel(FinalProject.Models.FinalProjectContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contractor = await _context.Contractor.FindAsync(id);

            if (Contractor != null)
            {
                _context.Contractor.Remove(Contractor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
