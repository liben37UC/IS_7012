using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [CustomValidation(typeof(Manufacturer), "ManuNameValidation")]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }

        public ICollection<Collectible> Collectibles { get; set; }

        [NotMapped]
        public string DisplayName
        {
            // CONCATENATE THE FIRST AND LAST NAME
            // INTO A DISPLAY NAME
            get { return $"{ID}"; }
        }
        public static ValidationResult ManuNameValidation(string ManufacturerName, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(ManufacturerName))
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Manufacturer;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            // GET THE DATABASE
            var dbContext = context.GetService(typeof(CoreCrudContext)) as CoreCrudContext;
            // WE NEED INCLUDE THE ID IN THE QUERY SO THAT IF WE ARE EDITING A CATEGORY 
            // WE DO NOT FIND THE CURRENT CATEGORY AND ACCIDENTLY CALL IT A DUPLICATE
            int duplicateCount = dbContext.Manufacturer
                                          .Count(x => x.ID != instance.ID && x.ManufacturerName == ManufacturerName);
            if (duplicateCount > 0)
            {
                return new ValidationResult($"Name {ManufacturerName} already exists");
            }
            return ValidationResult.Success;
        }
    }
}
