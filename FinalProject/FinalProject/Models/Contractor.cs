using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Contractor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a first name")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "2-80 characters only")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide a last name")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "2-80 characters only")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please provide a Start Date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Contractor), "StartDateValidation")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please provide a Start Date")]
        [DataType(DataType.Date)]
        //[CustomValidation(typeof(Collectible), "CreateDateinPast")]
        [Display(Name = "Planned End Date")]
        public DateTime PlannedEndDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Actual End Date")]
        public DateTime? ActualEndDate { get; set; }



        public string WorkStatus { get; set; }


        [CustomValidation(typeof(Contractor), "RatingValidation")]
        public decimal? Rating { get; set; }







        [Display(Name = "Business Name")]
        public int BusinessID { get; set; }

        public Business Business { get; set; }

        public int ProjectID { get; set; }

        public Project Project { get; set; }

        public static ValidationResult StartDateValidation(DateTime? StartDate, ValidationContext context)
        {
            if (StartDate == null)
            {
                return ValidationResult.Success;
            }
            if (StartDate.Value.Date <= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            string errorMessage = $"Contractor start date must be a date on or before { DateTime.Today.ToShortDateString() }";
            return new ValidationResult(errorMessage);
        }

        public static ValidationResult RatingValidation(decimal? Rating, ValidationContext context)
        {
            if (Rating <= 10 && Rating > 0 )
            {
                return ValidationResult.Success;
            }
            if (Rating == null)
            {
                return ValidationResult.Success;
            }
            string errorMessage = "Rating must be between 1 and 10";
            return new ValidationResult(errorMessage);
        }



        [NotMapped]
        public string DisplayPerformanceRating
        {
            get
            {

                if (Rating < 4)
                {
                    return "Poor";
                }

                else if (Rating >= 4 && Rating < 7)
                {
                    return "Okay";
                }

                else if (Rating > 7)
                {
                    return "Great";
                }
                else
                {
                    return "N/A";
                }
            }
        }
    }
}