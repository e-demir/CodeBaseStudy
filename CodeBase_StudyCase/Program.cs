using System.Text;

public class RoverForNASA
{
    public static void Main()
    {
        bool addMoreRovers = true;
        StringBuilder sb = new();
        ConsoleKey addOrNot;
        Console.WriteLine("Enter plateau coordinates (e.g., 5 5):");
        string plateauCoordinates = Console.ReadLine();        

        if (TryParseCoordinates(plateauCoordinates, out int plateauX, out int plateauY))
        {           
            while (addMoreRovers)
            {
                Console.WriteLine("Enter the postion information of Rover:");
                string roverPosition = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(roverPosition))
                    break;

                Console.WriteLine("Enter instructions for Rover:");
                string roverInstructions = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(roverInstructions))
                    break;                
                
                do
                {
                    Console.WriteLine("Will you add more rovers? [Y/N]");
                    addOrNot = Console.ReadKey(false).Key;

                    if (addOrNot != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (addOrNot != ConsoleKey.Y && addOrNot != ConsoleKey.N);

                if (TryParseRoverPosition(roverPosition, out int roverX, out int roverY, out char roverDirection))
                {
                    MoveRover(plateauX, plateauY, ref roverX, ref roverY, ref roverDirection, roverInstructions);                                       
                    
                    sb.AppendLine($"{roverX} {roverY} {roverDirection}");
                }
                else
                {
                    sb.AppendLine("Invalid rover position input. Please try again.");
                }
                if (addOrNot.ToString() == "N")
                {
                    addMoreRovers = false;
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid plateau coordinates input.");
        }

        Console.WriteLine(sb.ToString());
    }

    public static void MoveRover(int plateauX, int plateauY, ref int roverX, ref int roverY, ref char roverDirection, string instructions)
    {
        foreach (char instruction in instructions)
        {
            switch (instruction)
            {
                case 'L':
                    RotateLeft(ref roverDirection);
                    break;

                case 'R':
                    RotateRight(ref roverDirection);
                    break;

                case 'M':
                    MoveForward(plateauX, plateauY, ref roverX, ref roverY, roverDirection);
                    break;

                default:
                    Console.WriteLine($"Invalid instruction: {instruction}");
                    break;
            }
        }
    }

    public static void RotateLeft(ref char direction)
    {
        switch (direction)
        {
            case 'N':
                direction = 'W';
                break;

            case 'E':
                direction = 'N';
                break;

            case 'S':
                direction = 'E';
                break;

            case 'W':
                direction = 'S';
                break;
        }
    }

    public static void RotateRight(ref char direction)
    {
        switch (direction)
        {
            case 'N':
                direction = 'E';
                break;

            case 'E':
                direction = 'S';
                break;

            case 'S':
                direction = 'W';
                break;

            case 'W':
                direction = 'N';
                break;
        }
    }

    public static void MoveForward(int plateauX, int plateauY, ref int roverX, ref int roverY, char direction)
    {
        switch (direction)
        {
            case 'N':
                if (roverY < plateauY)
                    roverY++;
                break;

            case 'E':
                if (roverX < plateauX)
                    roverX++;
                break;

            case 'S':
                if (roverY > 0)
                    roverY--;
                break;

            case 'W':
                if (roverX > 0)
                    roverX--;
                break;
        }
    }

    public static bool TryParseCoordinates(string input, out int x, out int y)
    {
        x = 0;
        y = 0;

        string[] parts = input.Split(' ');
        if (parts.Length == 2 && int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y))
        {
            return true;
        }

        return false;
    }

    public static bool TryParseRoverPosition(string input, out int x, out int y, out char direction)
    {
        x = 0;
        y = 0;
        direction = 'N';

        string[] parts = input.Split(' ');
        if (parts.Length == 3 && int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y) && char.TryParse(parts[2], out direction))
        {
            return true;
        }

        return false;
    }
}
