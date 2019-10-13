using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{

    public class EndProjectModel : PageModel
{
        private readonly FinalProjectContext _context;
        public EndProjectModel(FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EndProject EndProject { get; set; }

        public Project Project { get; set; }
        public IList<Contractor> Contractor { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = _context.Project.Find(id);

            if (Project == null)
            {
                return NotFound();
            }

            EndProject = new EndProject();
            EndProject.ProjectId = Project.ID;
            return Page();
        }
        public IActionResult OnPost()
        {
            Project = _context.Project.Find(EndProject.ProjectId);
            Contractor = _context.Contractor.Where(b => b.ProjectID == EndProject.ProjectId).ToList();

            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach (var contrac in Contractor)
            {
                contrac.ActualEndDate = EndProject.EndDate;
                contrac.WorkStatus = "no allocation";
            }

            Project.ActualEndDate = EndProject.EndDate;

            _context.SaveChanges();
            return RedirectToPage("/Projects/Index");
        }
    }
 }