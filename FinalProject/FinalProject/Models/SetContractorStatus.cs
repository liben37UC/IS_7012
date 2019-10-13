using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class SetContractorStatus
    {

        public SetContractorStatus()
        {
            EndDate = DateTime.Today;

        }

        public int ContractorId { get; set; }
        public string status { get; set; }


        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
