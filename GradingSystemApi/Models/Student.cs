using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GradingSystem.utils;

namespace GradingSystem.models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }
        public string name { get; set; }

        public string average { get; set; }
        public List<Grade> grades { get; set; }

        // Foreign key
        public int CohortId { get; set; }
        // Navigation property

        [JsonIgnore] 
        public Cohort? Cohort { get; set; }

        public Student(string name, int CohortId)
        {
            this.name = name;
            this.CohortId = CohortId;
            this.grades = new List<Grade>();
            this.average = Grader.GradeAverage(grades);

        }

        public string GetAverage()
        {
            return Grader.GradeAverage(grades);
        }
    }
}