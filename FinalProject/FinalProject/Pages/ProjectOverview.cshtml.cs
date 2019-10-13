using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinalProject.Models;

namespace FinalProject.Pages
{
    public class ProjectOverviewModel : PageModel
    {
        private FinalProjectContext _context;

        public ProjectOverviewModel(FinalProjectContext context)
        {
            _context = context;
        }


        public IList<Project> Projects { get; set; }



        public IActionResult OnGet(string sort)
        {

            if (sort == "costs")
            {
                Projects = _context.Project.OrderByDescending(x => x.RunningTotalCost).ToList();

            }
            else if (sort == "budget")
            {
                Projects = _context.Project.OrderByDescending(x => x.Budget).ToList();
            }
            else
            {
                Projects = _context.Project.ToList();

            }

            return Page();

        }
    }
}