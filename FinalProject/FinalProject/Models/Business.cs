using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Business
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Please provide a business name")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "2-80 characters only")]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Please provide a business type")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "2-80 characters only")]
        [Display(Name = "Business Type")]
        public string BusinessType { get; set; }


        [Required(ErrorMessage = "Please provide a country for the business")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "2-80 characters only")]
        [Display(Name = "Country")]
        public string BusinessCountry { get; set; }



        [Display(Name = "Number of Employees")]
        [CustomValidation(typeof(Business), "NumberofEmployeesValidation")]
        public int? NumberEmployees { get; set; }

        public ICollection<Contractor> Contractors { get; set; }

        public bool IsOpen
        {
            //RETURN TRUE/FALSE DPENDING ON IF THE ESTABLISHMENT HAS A CLOSE DATE
            get { return NumberEmployees == null; }
        }

        [NotMapped]
        public string DisplayBusinessSize
        {
            get
            {

                if (NumberEmployees < 100)
                {
                    return "Small";
                }

                else if (NumberEmployees >= 100 && NumberEmployees < 5000)
                {
                    return "Medium";
                }

                else if (NumberEmployees >= 5000)
                {
                    return "Large";
                }
                else
                {
                    return "N/A";
                }
            }
        }

        public static ValidationResult NumberofEmployeesValidation(int? NumberEmployees, ValidationContext context)
        {
            if (NumberEmployees == null)
            {
                return ValidationResult.Success;
            }

            var instance = context.ObjectInstance as Business;
            if (instance == null)
            {
                return ValidationResult.Success;
            }

            if (instance.IsOpen && NumberEmployees == 0)
            {
                return new ValidationResult($"Employee count must be > 0 if the business is marked as open");
            }
            return ValidationResult.Success;
        }
    }
}