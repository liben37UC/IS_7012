using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }

        public string ManufacturerName { get; set; }

        public ICollection<Collectible> Collectibles { get; set; }

        [NotMapped]
        public string DisplayName
        {
            // CONCATENATE THE FIRST AND LAST NAME
            // INTO A DISPLAY NAME
            get { return $"{ID}"; }
        }
    }
}
