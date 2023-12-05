using GradingSystem.utils;

namespace GradingSystem.models
{
    public class Student
    {
        public string name { get; set; }
        public List<Grade> grades { get; set; }

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