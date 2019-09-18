using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Collectible
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public decimal Weight { get; set; }

        public bool Electronic { get; set; }

        public string Material { get; set; }

        [NotMapped]
        public string DisplayWeightClass
        {
            get
            {

                if (Weight < 10)
                {
                    return "LIGHT";
                }

                if (Weight >= 10 && Weight < 20)
                {
                    return "Average";
                }

                else
                {
                    return "Heavy";
                }
            }
        }

        public int ManufacturerID { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
