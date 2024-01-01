using System.Collections.Generic;
using GradingSystem.models;

namespace GradingSystem.utils
{
    public class Grader
    {
        public static string GradeExam(int grade)
        {
            if (grade >= 90 && grade <= 100)
            {
                return "A";
            }
            else if (grade >= 75 && grade <= 89)
            {
                return "B";
            }
            else if (grade >= 60 && grade <= 74)
            {
                return "C";
            }
            else if (grade >= 45 && grade <= 59)
            {
                return "D";
            }
            else if (grade >= 0 && grade <= 44)
            {
                return "F";
            }
            else
            {
                return "Invalid grade";
            }
        }

        public static double GradeAverage(List<Grade> grades)
        {
            int sum = 0;

            foreach (Grade grade in grades)
            {
                sum += grade.numberGrade;
            }

            double result = (double)sum / grades.Count;

            return result;
        }

        public static double CohortAverage(List<Student> students)
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

            return result;
        }

    }
}
