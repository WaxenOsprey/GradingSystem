using GradingSystem.models;
using GradingSystem.data;
using System;
using System.Linq;

public static class DataLoader
{
    public static void Initialize(GradingSystemContext context)
    {
        // Check if the database has been seeded
        // if (context.Cohorts.Any() || context.Students.Any() || context.Grades.Any())
        // {
        //     Console.WriteLine("Data already exists. Skipping seed.");
        //     return;
        // }

        SeedData(context);
    }

    private static void SeedData(GradingSystemContext context)
    {
        // Add sample data here
        var cohort = new Cohort("Cohort 1");
        var cohort2 = new Cohort("Cohort 2");
        






        // Add the entities to the context
        context.Cohorts.Add(cohort);
        context.Cohorts.Add(cohort2);
        // context.Students.Add(student);
        // context.Grades.Add(grade);

        // Save changes to the database
        context.SaveChanges();
        Console.WriteLine("Data seeded successfully.");
    }
}
