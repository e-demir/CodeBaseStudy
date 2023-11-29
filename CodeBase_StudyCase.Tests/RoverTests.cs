using Xunit;

public class RoverTests
{
    [Fact]
    public void MoveRover_Forward_North_ShouldIncrementY()
    {
        // Arrange
        var plateauX = 5;
        var plateauY = 5;
        var roverX = 1;
        var roverY = 2;
        var roverDirection = 'N';
        var instructions = "M";

        // Act
        RoverForNASA.MoveRover(plateauX, plateauY, ref roverX, ref roverY, ref roverDirection, instructions);

        // Assert
        Assert.Equal(3, roverY);
    }

    [Fact]
    public void MoveRover_Forward_East_ShouldIncrementX()
    {
        // Arrange
        var plateauX = 5;
        var plateauY = 5;
        var roverX = 1;
        var roverY = 2;
        var roverDirection = 'E';
        var instructions = "M";

        // Act
        RoverForNASA.MoveRover(plateauX, plateauY, ref roverX, ref roverY, ref roverDirection, instructions);

        // Assert
        Assert.Equal(2, roverX);
    }

    [Fact]
    public void MoveRover_Forward_South_ShouldDecrementY()
    {
        // Arrange
        var plateauX = 5;
        var plateauY = 5;
        var roverX = 1;
        var roverY = 2;
        var roverDirection = 'S';
        var instructions = "M";

        // Act
        RoverForNASA.MoveRover(plateauX, plateauY, ref roverX, ref roverY, ref roverDirection, instructions);

        // Assert
        Assert.Equal(1, roverY);
    }

    [Fact]
    public void MoveRover_Forward_West_ShouldDecrementX()
    {
        // Arrange
        var plateauX = 5;
        var plateauY = 5;
        var roverX = 1;
        var roverY = 2;
        var roverDirection = 'W';
        var instructions = "M";

        // Act
        RoverForNASA.MoveRover(plateauX, plateauY, ref roverX, ref roverY, ref roverDirection, instructions);

        // Assert
        Assert.Equal(0, roverX);
    }

    [Fact]
    public void MoveRover_RotateLeft_FromNorth_ShouldFaceWest()
    {
        // Arrange
        var roverDirection = 'N';

        // Act
        RoverForNASA.RotateLeft(ref roverDirection);

        // Assert
        Assert.Equal('W', roverDirection);
    }

    [Fact]
    public void MoveRover_RotateRight_FromEast_ShouldFaceSouth()
    {
        // Arrange
        var roverDirection = 'E';

        // Act
        RoverForNASA.RotateRight(ref roverDirection);

        // Assert
        Assert.Equal('S', roverDirection);
    }

    [Fact]
    public void MoveRover_RotateLeftTwice_FromSouth_ShouldFaceNorth()
    {
        // Arrange
        var roverDirection = 'S';

        // Act
        RoverForNASA.RotateLeft(ref roverDirection);
        RoverForNASA.RotateLeft(ref roverDirection);

        // Assert
        Assert.Equal('N', roverDirection);
    }

    [Fact]
    public void MoveRover_RotateRightTwice_FromWest_ShouldFaceEast()
    {
        // Arrange
        var roverDirection = 'W';

        // Act
        RoverForNASA.RotateRight(ref roverDirection);
        RoverForNASA.RotateRight(ref roverDirection);

        // Assert
        Assert.Equal('E', roverDirection);
    }

    [Fact]
    public void MoveRover_ComplexInstructions_ShouldReachExpectedPosition()
    {
        // Arrange
        var plateauX = 5;
        var plateauY = 5;
        var roverX = 1;
        var roverY = 2;
        var roverDirection = 'N';
        var instructions = "LMLMLMLMM";

        // Act
        RoverForNASA.MoveRover(plateauX, plateauY, ref roverX, ref roverY, ref roverDirection, instructions);

        // Assert
        Assert.Equal(1, roverX);
        Assert.Equal(3, roverY);
        Assert.Equal('N', roverDirection);
    }

    [Fact]
    public void MoveRover_BeyondPlateauBounds_ShouldStayWithinBounds()
    {
        // Arrange
        var plateauX = 5;
        var plateauY = 5;
        var roverX = 4;
        var roverY = 4;
        var roverDirection = 'E';
        var instructions = "MMMMMMMMMM";

        // Act
        RoverForNASA.MoveRover(plateauX, plateauY, ref roverX, ref roverY, ref roverDirection, instructions);

        // Assert
        Assert.Equal(5, roverX);
        Assert.Equal(4, roverY);
        Assert.Equal('E', roverDirection);
    }
}
