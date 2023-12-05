using System;
using System.Collections.Generic;
using GradingSystem.utils;
using GradingSystem.models;

class Program
{
    static void Main()
    {
        Cohort cohort = new Cohort("Craneware 1");
        cohort.students.Add(new Student("John"));
        cohort.students.Add(new Student("Jane"));
        cohort.students.Add(new Student("Jack"));

        cohort.students[0].grades.Add(new Grade(90));
        cohort.students[0].grades.Add(new Grade(80));
        cohort.students[0].grades.Add(new Grade(70));
        cohort.students[0].grades.Add(new Grade(50));
        cohort.students[0].grades.Add(new Grade(30));


        Console.WriteLine();
        Console.WriteLine("************* Welcome to the grading system! *************");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Select an option: ");
            Console.WriteLine();
            Console.WriteLine("1 - View cohort");
            Console.WriteLine("2 - Add student to cohort");
            Console.WriteLine("3 - Exit");
            Console.WriteLine();

            string? mainOptionNullable = Console.ReadLine();
            string mainOption = mainOptionNullable ?? string.Empty;

            if (mainOption == "") continue;

            if (mainOption == "1")
            {
                Console.WriteLine();
                Console.WriteLine($"Cohort name: {cohort.name}");
                Console.WriteLine($"Number of students: {cohort.students.Count}");
                Console.WriteLine($"Cohort average: {cohort.GetCohortAverage()}");
                Console.WriteLine();

                for (int i = 0; i < cohort.students.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {cohort.students[i].name}");
                }

                Console.WriteLine();
                Console.WriteLine("Select a student (enter the corresponding number): ");
                string? studentSelection = Console.ReadLine();
                int selectedStudentIndex;

                if (int.TryParse(studentSelection, out selectedStudentIndex) &&
                    selectedStudentIndex >= 1 && selectedStudentIndex <= cohort.students.Count)
                {
                    Student selectedStudent = cohort.students[selectedStudentIndex - 1];
                    Console.WriteLine();
                    Console.WriteLine($"Selected student: {selectedStudent.name}");

                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Select an option: ");
                        Console.WriteLine();
                        Console.WriteLine("1 - View grades");
                        Console.WriteLine("2 - Add grade");
                        Console.WriteLine("3 - Back to main menu");
                        Console.WriteLine();

                        string? studentOptionNullable = Console.ReadLine();
                        string studentOption = studentOptionNullable ?? string.Empty;

                        if (studentOption == "") continue;

                        if (studentOption == "1")
                        {
                            // View grades of the selected student
                            Console.WriteLine($"Grades of {selectedStudent.name}:");
                            Console.WriteLine();

                            foreach (Grade grade in selectedStudent.grades)
                            {
                                Console.Write($"- {grade.numberGrade}/100 ");
                                Console.ForegroundColor = GradeColor.GetColorForGrade(grade.letterGrade);
                                Console.WriteLine($"({grade.letterGrade})");
                                Console.ResetColor();                            
                            }
                            Console.WriteLine();
                            Console.WriteLine($"Average: {selectedStudent.GetAverage()}");
                        }
                        else if (studentOption == "2")
                        {
                            // Add a new grade for the selected student
                            Console.WriteLine("Enter a grade: ");
                            Console.WriteLine();
                            string? newGradeString = Console.ReadLine();
                            if (int.TryParse(newGradeString, out int newGrade))
                            {
                                selectedStudent.grades.Add(new Grade(newGrade));
                                Console.WriteLine($"Grade {newGrade} added for {selectedStudent.name}");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Invalid grade. Please try again.");
                            }
                        }
                        else if (studentOption == "3")
                        {
                            break; // Go back to the main menu
                        }
                        else
                        {
                            Console.WriteLine("Invalid option");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }
            else if (mainOption == "2")
            {
                // Add a new student to the cohort
                Console.WriteLine();
                Console.WriteLine("Enter student name: ");
                Console.WriteLine();
                string? nameNullable = Console.ReadLine();
                string name = nameNullable ?? string.Empty;
                if (name == "") continue;
                cohort.students.Add(new Student(name));
                Console.WriteLine($"{name} added to cohort");
                Console.WriteLine();
            }
            else if (mainOption == "3")
            {
                Console.WriteLine();
                Console.WriteLine("Exiting...");
                Console.WriteLine();
                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid option");
                Console.WriteLine();
            }
        }
    }
}
