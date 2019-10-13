using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class EndProject
    {

        public EndProject()
        {
            EndDate = DateTime.Today;

        }

        public int ProjectId { get; set; }


        [Display(Name = "Actual End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
