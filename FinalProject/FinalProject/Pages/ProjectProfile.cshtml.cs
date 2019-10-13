using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages
{
    public class ProjectProfileModel : PageModel
    {
        private FinalProjectContext _context;

        public ProjectProfileModel(FinalProjectContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }
        public IList<Contractor> Contractors { get; set; }



        public IActionResult OnGet(int? id)
        {
            int length = _context.Project.ToList().Count;

            if (id == null || id > length)
            {
                return NotFound();
            }
            Project = _context.Project.Single(a => a.ID == id);
            Contractors = _context.Contractor.Where(b => b.ProjectID == id).Include(c => c.Business).ToList();

            return Page();

        }
    }
}