using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCrud.Models;

namespace CoreCrud.Pages
{
    public class ManufacturerProfileModel : PageModel
    {
        private CoreCrudContext _context;

        public ManufacturerProfileModel(CoreCrudContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }
        public ICollection<Collectible> Collectibles { get; set; }



        public IActionResult OnGet(int? id)
        {
            int length = _context.Manufacturer.ToList().Count;

            if (id == null || id > length)
            {
                return NotFound();
            }
            Manufacturer = _context.Manufacturer.Single(a => a.ID == id);
            Collectibles = _context.Collectible.Where(b => b.ManufacturerID == id).ToList();

            return Page();

        }
    }
}