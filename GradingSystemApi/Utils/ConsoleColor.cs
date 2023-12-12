namespace GradingSystem.utils
{
    public class GradeColor
    {
        public static ConsoleColor GetColorForGrade(string grade)
        {
            if (grade == "A")
            {
                return ConsoleColor.Green;
            }
            else if (grade == "B")
            {
                return ConsoleColor.Blue;
            }
            else if (grade == "C")
            {
                return ConsoleColor.Yellow;
            }
            else if (grade == "D")
            {
                return ConsoleColor.Magenta;
            }
            else if (grade == "F")
            {
                return ConsoleColor.Red;
            }
            else
            {
                return ConsoleColor.White;
            }
        }
    }
}
