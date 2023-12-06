using System.ComponentModel.DataAnnotations;
using GradingSystem.utils;

namespace GradingSystem.models
{
    public class Grade
    {
        [Key]
        public int gradeId { get; set; }
        public int numberGrade { get; set; }
        public string letterGrade { get; set; }

        public Grade(int numberGrade)
        {
            this.numberGrade = numberGrade;
            this.letterGrade = Grader.GradeExam(numberGrade);
        }

        public String GetGrade()
        {
            return $"Your grade is {letterGrade}";
        }

    }
}