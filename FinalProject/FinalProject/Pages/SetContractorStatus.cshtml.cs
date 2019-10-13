using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinalProject.Pages
{
    public class SetContractorStatusModel : PageModel
    {
        private readonly FinalProjectContext _context;
        public SetContractorStatusModel(FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SetContractorStatus SetContractorStatus { get; set; }

        public Contractor Contractor { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Contractor = _context.Contractor.Find(id);

            if (Contractor == null)
            {
                return NotFound();
            }

            SetContractorStatus = new SetContractorStatus();
            SetContractorStatus.ContractorId = Contractor.ID;
            return Page();
        }
        public IActionResult OnPost()
        {
            Contractor = _context.Contractor.Find(SetContractorStatus.ContractorId);


            if (!ModelState.IsValid)
            {
                return Page();
            }


            Contractor.WorkStatus= SetContractorStatus.status;
            Contractor.ActualEndDate = SetContractorStatus.EndDate;

            _context.SaveChanges();
            return RedirectToPage("/Contractors/Index");
        }
    }
}