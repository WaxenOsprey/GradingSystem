using System;
using Microsoft.EntityFrameworkCore;
using GradingSystem.models; 
using GradingSystem.data;


class DatabaseSandbox
{
    static void Main()
    {
        using (var dbContext = new GradingSystemContext())
        {
            try
            {
                // Your database operations here
                var entities = dbContext.Students.ToList(); 

                foreach (var entity in entities)
                {
                    Console.WriteLine(entity.name.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
