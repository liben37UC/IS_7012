using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
        private CoreCrudContext _context;

        public IndexModel(CoreCrudContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }
        public ICollection<Collectible> Collectibles { get; set; }

        public int number_manu { get; set; }
        public int number_coll { get; set; }

        public int num_heavy { get; set; }

        public int num_light { get; set; }

        public void OnGet()
        {
            number_manu = _context.Manufacturer.ToList().Count;
            number_coll = _context.Collectible.ToList().Count;
            num_heavy = _context.Collectible.Where(b => b.Weight < 5).ToList().Count;
            num_light = _context.Collectible.Where(b => b.Weight > 10).ToList().Count;

        }
    }
}
