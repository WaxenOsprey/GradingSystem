using GradingSystem.utils;

namespace GradingSystemTests;

public class ColorTests
{
    [Fact]
    public void GetColorForGrade_ReturnsGreenForA()
    {
        // Arrange
        string grade = "A";

        // Act
        ConsoleColor color = GradeColor.GetColorForGrade(grade);

        // Assert
        Assert.Equal(ConsoleColor.Green, color);

    }
}