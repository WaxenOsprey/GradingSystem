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
    var cohort1 = new Cohort("Cohort 1");
    context.Cohorts.Add(cohort1);
    context.SaveChanges();

    var cohort2 = new Cohort("Cohort 2");
    context.Cohorts.Add(cohort2);
    context.SaveChanges();

    var cohort3 = new Cohort("Cohort 3");
    context.Cohorts.Add(cohort3);
    context.SaveChanges();

    var student1Cohort1 = new Student("James", cohort1.cohortId);
    AddGradesToStudent(student1Cohort1, context);

    var student2Cohort1 = new Student("Robin", cohort1.cohortId);
    AddGradesToStudent(student2Cohort1, context);

    var student3Cohort1 = new Student("Sorcha", cohort1.cohortId);
    AddGradesToStudent(student3Cohort1, context);

    var student1Cohort2 = new Student("Andrew", cohort2.cohortId);
    AddGradesToStudent(student1Cohort2, context);

    var student2Cohort2 = new Student("Angela", cohort2.cohortId);
    AddGradesToStudent(student2Cohort2, context);

    var student3Cohort2 = new Student("Robert", cohort2.cohortId);
    AddGradesToStudent(student3Cohort2, context);

    var student1Cohort3 = new Student("Megan", cohort3.cohortId);
    AddGradesToStudent(student1Cohort3, context);

    var student2Cohort3 = new Student("Sarah", cohort3.cohortId);
    AddGradesToStudent(student2Cohort3, context);

    var student3Cohort3 = new Student("Tomas", cohort3.cohortId);
    AddGradesToStudent(student3Cohort3, context);
}


private static void AddGradesToStudent(Student student, GradingSystemContext context)
{
    if (context.Cohorts.Any(c => c.cohortId == student.CohortId))
    {
        for (int i = 1; i <= 5; i++)
        {
            var grade = new Grade(GenerateRandomGrade())
            {
                Student = student
            };

            student.grades.Add(grade);
            Console.WriteLine($"Added grade {grade.numberGrade} to student {student.name}");
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
    Random random = new Random();
    int grade = random.Next(0, 101);
    Console.WriteLine($"Generated random grade: {grade}");
    return grade;
}

}
