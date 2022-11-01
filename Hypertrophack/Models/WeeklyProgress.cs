using Hypertrophack.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace Hypertrophack.Models
{
    public class WeeklyProgress
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime WeekStart { get; set; }

        [Display(Name = "Chest")]
        public int ChestSets { get; set; }

        [Display(Name = "Back")]
        public int BackSets { get; set; }

        [Display(Name = "Legs")]
        public int LegSets { get; set; }

        [Display(Name = "Arms")]
        public int ArmSets { get; set; }

        [Display(Name = "Shoulders")]
        public int ShoulderSets { get; set; }
    }
}
