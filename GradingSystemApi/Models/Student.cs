using System.ComponentModel.DataAnnotations;
using GradingSystem.utils;

namespace GradingSystem.models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }
        public string name { get; set; }
        public List<Grade> grades { get; set; }

        // Foreign key
        public int CohortId { get; set; }
        // Navigation property
        public Cohort Cohort { get; set; }

        public Student(string name)
        {
            this.name = name;
            this.grades = new List<Grade>();
        }

        public string GetAverage()
        {
            return Grader.GradeAverage(grades);
        }
    }
}