using GradingSystem.models;
using GradingSystem.data;
using System;
using System.Linq;

public static class DataLoader
{
    public static void Initialize(GradingSystemContext context)
    {
        // Check if the database has been seeded
        if (context.Cohorts.Any() || context.Students.Any() || context.Grades.Any())
        {
            Console.WriteLine("Data already exists. Skipping seed.");
            return;
        }

        SeedData(context);
    }

    private static void SeedData(GradingSystemContext context)
    {
        // Step 1: Create Cohorts
        // Cohort 1
        var cohort1 = new Cohort("Cohort 1");
        context.Cohorts.Add(cohort1);
        context.SaveChanges();

        // Cohort 2
        var cohort2 = new Cohort("Cohort 2");
        context.Cohorts.Add(cohort2);
        context.SaveChanges();

        // Cohort 3
        var cohort3 = new Cohort("Cohort 3");
        context.Cohorts.Add(cohort3);
        context.SaveChanges();

        // Step 2: Create Students referencing Cohorts
        // Cohort 1 students
        var student1Cohort1 = new Student("James", cohort1.cohortId);
        AddGradesToStudent(student1Cohort1, context);

        var student2Cohort1 = new Student("Robin", cohort1.cohortId);
        AddGradesToStudent(student2Cohort1, context);

        var student3Cohort1 = new Student("Sorcha", cohort1.cohortId);
        AddGradesToStudent(student3Cohort1, context);

        // Cohort 2 students
        var student1Cohort2 = new Student("Andrew", cohort2.cohortId);
        AddGradesToStudent(student1Cohort2, context);

        var student2Cohort2 = new Student("Angela", cohort2.cohortId);
        AddGradesToStudent(student2Cohort2, context);

        var student3Cohort2 = new Student("Robert", cohort2.cohortId);
        AddGradesToStudent(student3Cohort2, context);

        // Cohort 3 students
        var student1Cohort3 = new Student("Megan", cohort3.cohortId);
        AddGradesToStudent(student1Cohort3, context);

        var student2Cohort3 = new Student("Sarah", cohort3.cohortId);
        AddGradesToStudent(student2Cohort3, context);

        var student3Cohort3 = new Student("Tomas", cohort3.cohortId);
        AddGradesToStudent(student3Cohort3, context);

        // Save changes to the database
        context.SaveChanges();
        Console.WriteLine("Data seeded successfully.");
    }

    private static void AddGradesToStudent(Student student, GradingSystemContext context)
    {
        // Check if the CohortId is valid
        if (context.Cohorts.Any(c => c.cohortId == student.CohortId))
        {
            // Step 3: Create Grades referencing Students
            for (int i = 1; i <= 5; i++)
            {
                var grade = new Grade(GenerateRandomGrade())
                {
                    Student = student
                };

                context.Grades.Add(grade);
            }

            context.Students.Add(student);
        }
        else
        {
            Console.WriteLine($"Invalid CohortId {student.CohortId} for student {student.name}. Student not added.");
        }
    }

    private static int GenerateRandomGrade()
    {
        // Generate a random grade for the purpose of seeding
        Random random = new Random();
        return random.Next(0, 101); // Assuming grades are between 0 and 100
    }
}
