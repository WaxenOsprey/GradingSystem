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
    }
}