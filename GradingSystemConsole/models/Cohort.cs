using System.ComponentModel.DataAnnotations;

namespace GradingSystem.models
{
    public class Cohort
    {
        [Key]
        public int cohortId { get; set; }
        public string name { get; set; }

        public List<Student> students { get; set; }

        public Cohort(string name)
        {
            this.name = name;
            this.students = new List<Student>();
        }
        public string GetCohortAverage()
        {
            int sum = 0;
            int count = 0;

            foreach (Student student in students)
            {
                foreach (Grade grade in student.grades)
                {
                    sum += grade.numberGrade;
                    count++;
                }
            }

            double result = (double)sum / count;

            return $"Average score is {result:F2}";
        }


    }
}