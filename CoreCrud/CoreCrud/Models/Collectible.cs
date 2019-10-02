using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Models
{
    public class Collectible
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a name")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "2-80 characters only")]
        [CustomValidation(typeof(Collectible), "CollectibleNameValidation")]
        [Display(Name = "Toy Name")]
        public string Name { get; set; }



        [DataType(DataType.Date)]
        [CustomValidation(typeof(Collectible), "CreateDateinPast")]
        [Display(Name = "Creation Date")]
        public DateTime? CreationDate { get; set; }


        [Range(0, 100, ErrorMessage = "Weight can only be from 0-100")]
        public decimal? Weight { get; set; }

        public bool Electronic { get; set; }

        [CustomValidation(typeof(Collectible), "Types_Material")]
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



        public static ValidationResult Types_Material(string Material, ValidationContext context)
        {
            if (Material == null || Material == "cotton" || Material == "wood" || Material == "plastic")
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Material must be cotton, wood, or plastic");
        }


        public static ValidationResult CreateDateinPast(DateTime? closedDate, ValidationContext context)
        {
            if (closedDate == null)
            {
                return ValidationResult.Success;
            }
            if (closedDate < DateTime.Today)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Closed date must be in the past");
        }



        public static ValidationResult CollectibleNameValidation(string Name, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Collectible;
            if (instance == null)
            {
                return ValidationResult.Success;
            }
            // GET THE DATABASE
            var dbContext = context.GetService(typeof(CoreCrudContext)) as CoreCrudContext;
            // WE NEED INCLUDE THE ID IN THE QUERY SO THAT IF WE ARE EDITING A CATEGORY 
            // WE DO NOT FIND THE CURRENT CATEGORY AND ACCIDENTLY CALL IT A DUPLICATE
            int duplicateCount = dbContext.Collectible
                                          .Count(x => x.ID != instance.ID && x.Name == Name);
            if (duplicateCount > 0)
            {
                return new ValidationResult($"Name {Name} already exists");
            }
            return ValidationResult.Success;
        }

        [Display(Name = "Manufacturer Name")]
        public int ManufacturerID { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}