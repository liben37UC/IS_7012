using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class AuctionModel : PageModel
    {
        private CoreCrudContext _context;

        public AuctionModel(CoreCrudContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }
        public ICollection<Collectible> Collectibles { get; set; }



        public IActionResult OnGet()
        {

            Collectibles = _context.Collectible.Include(est => est.Manufacturer).ToList();

            return Page();

        }
    }
}