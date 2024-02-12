using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for each cardinal direction
        Console.WriteLine("For each direction, input Y/N if it is valid.");
        bool northValid = AskDirection("North");
        bool eastValid = AskDirection("East");
        bool southValid = AskDirection("South");
        bool westValid = AskDirection("West");

        // Print the compass
        Console.WriteLine("From here you can go:");
        if (northValid)
            Console.WriteLine("    N");
        if (westValid && eastValid)
            Console.WriteLine("W---|---E");
        else if (westValid)
            Console.WriteLine("    |---E");
        else if (eastValid)
            Console.WriteLine("W---|");
        if (southValid)
            Console.WriteLine("    S");

        // Ask the user for a bearing
        Console.WriteLine("Give a bearing (a number) for the direction in which you are going.");
        int bearing = NormalizeBearing(int.Parse(Console.ReadLine()));

        // Determine the direction based on the bearing
        string direction;
        if (bearing > 315 || bearing <= 45)
            direction = "north";
        else if (bearing > 45 && bearing <= 135)
            direction = "east";
        else if (bearing > 135 && bearing <= 225)
            direction = "south";
        else
            direction = "west";

        // Print the direction
        if (direction == "north" && !northValid)
            Console.WriteLine("You can't go north");
        else if (direction == "east" && !eastValid)
            Console.WriteLine("You can't go east");
        else if (direction == "south" && !southValid)
            Console.WriteLine("You can't go south");
        else if (direction == "west" && !westValid)
            Console.WriteLine("You can't go west");
        else
            Console.WriteLine("You are going " + direction);
    }

    static bool AskDirection(string direction)
    {
        Console.Write(direction + "? Y/N\n>");
        string input = Console.ReadLine();
        return input.Equals("Y", StringComparison.OrdinalIgnoreCase);
    }

    static int NormalizeBearing(int bearing)
    {
        while (bearing < 0)
            bearing += 360;
        while (bearing >= 360)
            bearing -= 360;
        return bearing;
    }
}
