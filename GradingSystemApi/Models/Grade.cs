using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GradingSystem.utils;

namespace GradingSystem.models
{
    public class Grade
    {
        [Key]
        public int gradeId { get; set; }
        public int numberGrade { get; set; }
        public string letterGrade { get; set; }

        // Foreign key
        public int StudentId { get; set; }
        // Navigation property
        [JsonIgnore]
        public Student? Student { get; set; }


        public Grade(int numberGrade)
        {
            this.numberGrade = numberGrade;
        }
    }
}