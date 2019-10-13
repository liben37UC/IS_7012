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
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Models.FinalProjectContext _context;

        public IndexModel(FinalProject.Models.FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Contractor> Contractor { get;set; }


        [BindProperty]
        public string Search { get; set; }

        // WE WILL USE THIS PROPERTY TO TRACK IF A SEARCH HAS BEEN PERFORMED
        public bool SearchCompleted { get; set; }

        public async Task OnGetAsync()
        {
            SearchCompleted = false;
            Contractor = await _context.Contractor
                .Include(c => c.Business)
                .Include(c => c.Project).ToListAsync();
        }


        public void OnPost()
        {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(Search))
            {
                // EXIT EARLY IF THERE IS NO SEARCH TERM PROVIDED
                Contractor = _context.Contractor
                    .Include(c => c.Business)
                    .Include(c => c.Project).ToList();
                return;
            }
            Contractor = _context.Contractor
                                    .Include(c => c.Business)
                                    .Include(c => c.Project)
                                    .Where(x => x.FirstName.ToLower().Contains(Search.ToLower()))
                                    .ToList();
            SearchCompleted = true;
        }
    }
}
