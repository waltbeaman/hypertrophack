using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hypertrophack.Models
{
    public class CompletedExercise
    {
        public int Id { get; set; }

        [Required]
        public string Exercise { get; set; } = null!;

        [Required]
        [Display(Name = "Muscle Group")]
        //public string MuscleGroupName { get; set; } = null!;
        public string MuscleGroup { get; set; } = null!;

        [Required]
        [Display(Name = "Sets")]
        public int Sets { get; set; }
        //public string UserName { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
