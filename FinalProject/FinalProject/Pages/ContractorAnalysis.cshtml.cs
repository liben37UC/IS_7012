using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Pages
{
    public class ContractorAnalysisModel : PageModel
    {
        private FinalProjectContext _context;

        public ContractorAnalysisModel(FinalProjectContext context)
        {
            _context = context;
        }


        public IList<Contractor> Contractors { get; set; }



        public void OnGet()
        {

            Contractors = _context.Contractor.
                Include(c => c.Business).
                Include(c => c.Project).
                OrderByDescending(x => x.Rating).ToList();

        }
    }
}