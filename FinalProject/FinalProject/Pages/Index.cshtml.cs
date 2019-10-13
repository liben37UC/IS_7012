using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class IndexModel : PageModel
    {
        private FinalProjectContext _context;

        public IndexModel(FinalProjectContext context)
        {
            _context = context;
        }


        public int number_businesses { get; set; }
        public int number_projects { get; set; }

        public int number_contractors { get; set; }


        public void OnGet()
        {
            number_businesses = _context.Business.ToList().Count;
            number_projects = _context.Project.ToList().Count;
            number_contractors = _context.Contractor.ToList().Count;

        }
    }
}
