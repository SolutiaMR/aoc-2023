namespace day2;

class Program
{
    static void Main(string[] args)
    {
        PartTwo();
    }

    public static void PartOne()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();

        var colors = new Dictionary<string, int>();
        colors.Add("red", 12);
        colors.Add("green", 13);
        colors.Add("blue", 14);
        var possibleGames = new List<string>();
        foreach (var line in lines)
        {
            var gameNumber = getGameNumber(line);
            var sets = line.Split(':')[1].Split(';');
            foreach (var item in sets)
            {
                var possibleColors = item.Split(',');
                foreach (var color in possibleColors)
                {
                    var trimmedColor = color.Trim();
                    var number = trimmedColor.Split(' ')[0];
                    var setColor = trimmedColor.Split(' ')[1]; ;
                    if (Convert.ToInt32(number) > colors[setColor])
                    {
                        goto BadGame;
                    }
                }
            }

            possibleGames.Add(gameNumber);
        BadGame:
            continue;
        }

        Console.WriteLine(possibleGames.Sum(x => Convert.ToInt32(x)).ToString());
    }

    public static void PartTwo()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();

        var colors = new Dictionary<string, int>();
        colors.Add("red", 12);
        colors.Add("green", 13);
        colors.Add("blue", 14);

        var minColors = new Dictionary<string, int>();
        minColors.Add("red", 0);
        minColors.Add("green", 0);
        minColors.Add("blue", 0);

        var possibleGames = new List<string>();
        var power = new List<int>();
        foreach (var line in lines)
        {
            minColors["red"] = 0;
            minColors["green"] = 0;
            minColors["blue"] = 0;
            var gameNumber = getGameNumber(line);
            var sets = line.Split(':')[1].Split(';');
            foreach (var item in sets)
            {
                var possibleColors = item.Split(',');
                foreach (var color in possibleColors)
                {
                    var trimmedColor = color.Trim();
                    //number of cubes in a set
                    var number = trimmedColor.Split(' ')[0];
                    var setColor = trimmedColor.Split(' ')[1];
                    // if (Convert.ToInt32(number) > colors[setColor])
                    // {
                    //     goto BadGame;
                    // }
                    if (Convert.ToInt32(number) > minColors[setColor])
                    {
                        minColors[setColor] = Convert.ToInt32(number);
                    }
                }
            }
            Console.WriteLine(minColors["red"] * minColors["green"] * minColors["blue"]);
            power.Add(minColors["red"] * minColors["green"] * minColors["blue"]);
        BadGame:
            continue;
        }

        Console.WriteLine(power.Sum(x => Convert.ToInt32(x)).ToString());
    }

    public static string getGameNumber(string input)
    {
        var space = input.IndexOf(' ');
        var colon = input.IndexOf(':');
        return input.Substring(space, colon - space);
    }
}