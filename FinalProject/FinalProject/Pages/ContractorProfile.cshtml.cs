using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class ContractorProfileModel : PageModel
    {
        private FinalProjectContext _context;

        public ContractorProfileModel(FinalProjectContext context)
        {
            _context = context;
        }

        public Contractor Contractor { get; set; }



        public IActionResult OnGet(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Contractor = _context.Contractor.Single(a => a.ID == id);

            return Page();

        }
    }
}