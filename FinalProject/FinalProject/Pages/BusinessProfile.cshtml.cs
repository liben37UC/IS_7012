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
    public class BusinessProfileModel : PageModel
    {
        private FinalProjectContext _context;

        public BusinessProfileModel(FinalProjectContext context)
        {
            _context = context;
        }

        public Business Business { get; set; }
        public IList<Contractor> Contractors { get; set; }



        public IActionResult OnGet(int? id)
        {
            int length = _context.Business.ToList().Count;

            if (id == null || id > length)
            {
                return NotFound();
            }
            Business = _context.Business.Single(a => a.ID == id);
            Contractors = _context.Contractor.Where(b => b.BusinessID == id).Include(c => c.Project).ToList();

            return Page();

        }
    }
}