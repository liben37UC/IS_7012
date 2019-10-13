using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Project
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please provide a project name")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "2-80 characters only")]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Please provide a Start Date")]
        [DataType(DataType.Date)]
        //[CustomValidation(typeof(Collectible), "CreateDateinPast")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please provide a Planned End Date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Project), "PlannedEndDateValidation")]
        [Display(Name = "Planned Date")]
        public DateTime PlannedEndDate { get; set; }

        [DataType(DataType.Date)]
        //[CustomValidation(typeof(Collectible), "CreateDateinPast")]
        [Display(Name = "Actual Date")]
        public DateTime? ActualEndDate { get; set; }

        [Required(ErrorMessage = "Please provide a Start Date")]
        //[Display(Name = "Start Date")]
        public int Budget { get; set; }


        [Display(Name = "Running Total Cost")]
        public decimal? RunningTotalCost { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        public ICollection<Contractor> Contractors { get; set; }

        public static ValidationResult PlannedEndDateValidation(DateTime? PlannedEndDate, ValidationContext context)
        {
            if (PlannedEndDate == null)
            {
                return ValidationResult.Success;
            }
            if (PlannedEndDate.Value.Date >= DateTime.Today)
            {
                return ValidationResult.Success;
            }
            string errorMessage = $"Projected end date of project must be a date on or after { DateTime.Today.ToShortDateString() }";
            return new ValidationResult(errorMessage);
        }

        [NotMapped]
        public string DisplayProjectSize
        {
            get
            {

                if (Budget < 40000)
                {
                    return "Small";
                }

                else if (Budget >= 40000 && Budget < 200000)
                {
                    return "Medium";
                }

                else if (Budget >= 200000)
                {
                    return "Large";
                }
                else
                {
                    return "N/A";
                }
            }
        }

        [NotMapped]
        public decimal BudgetRunning
        {
            get
            {
                if (Budget != null && RunningTotalCost != null)
                {
                    return Budget - (decimal)RunningTotalCost;
                }
                else
                {
                    return 0;
                }
            }
        }


    }
}
