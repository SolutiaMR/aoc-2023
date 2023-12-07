namespace day6;
using System.Text.Json;
class Program
{
    public class Race()
    {
        public long? time { get; set; }
        public long? distance { get; set; }

        public long? possiblities { get; set; } = 0;
    }
    static void Main(string[] args)
    {
        PartOne();
        PartTwo();
    }

    public static void PartOne()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();

        List<Race> races = new List<Race>();

        var rowIdx = 0;
        foreach (var line in lines)
        {
            var attributes = line.Split(":")[1].Trim().Split(" ").ToList().Where(x => x != "").ToList();

            var colIdx = 0;
            if (rowIdx == 0)
            {
                foreach (var attribute in attributes)
                {
                    races.Add(new Race()
                    {
                        time = long.Parse(attribute)
                    });
                    colIdx++;
                }
            }
            else
            {
                foreach (var attribute in attributes)
                {
                    races.ToArray()[colIdx].distance = long.Parse(attribute);
                    colIdx++;
                }
            }
            rowIdx++;
        }

        // hold down for x ms, subtract that from time, then multiply by remaining 
        // time to find the cases that allow you to surpass the distance
        var possibliities = new List<long>();
        foreach (var race in races)
        {
            Utils.PrintObject(race);
            //calculate minimum time needed then loop until you are holding it too long

            for (int i = 1; i < race.time; i++)
            {
                if (i * (race.time - i) > race.distance)
                {
                    race.possiblities += 1;
                }
            }
            // var time = (race.distance - race.time);
            // Console.WriteLine($"time: {time}");
            // while ((time * (race.time - time)) > race.distance)
            // {
            //     Console.WriteLine($"time f: {time}");
            //     race.possiblities = race.possiblities + 1;
            //     time += 1;
            // }
        }

        // Print the product of all possiblities properties
        long product = 1;
        foreach (var race in races)
        {
            if (race.possiblities.HasValue)
            {
                product *= race.possiblities.Value;
            }
        }
        Console.WriteLine($"Product of possiblities: {product}");
    }
    public static void PartTwo()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();

        List<Race> races = new List<Race>();

        var rowIdx = 0;
        foreach (var line in lines)
        {
            var attributes = line.Split(":")[1].Trim().Replace(" ", "");
            Console.WriteLine(attributes);
            var colIdx = 0;
            if (rowIdx == 0)
            {

                races.Add(new Race()
                {
                    time = long.Parse(attributes)
                });
                colIdx++;

            }
            else
            {

                races.ToArray()[colIdx].distance = long.Parse(attributes);
                colIdx++;

            }
            rowIdx++;
        }

        // hold down for x ms, subtract that from time, then multiply by remaining 
        // time to find the cases that allow you to surpass the distance

        foreach (var race in races)
        {
            Utils.PrintObject(race);
            //calculate minimum time needed then loop until you are holding it too long

            for (long i = 1; i < race.time; i++)
            {
                if (i * (race.time - i) > race.distance)
                {
                    race.possiblities += 1;
                }
            }
            // var time = (race.distance - race.time);
            // Console.WriteLine($"time: {time}");
            // while ((time * (race.time - time)) > race.distance)
            // {
            //     Console.WriteLine($"time f: {time}");
            //     race.possiblities = race.possiblities + 1;
            //     time += 1;
            // }
        }

        // Print the product of all possiblities properties
        long product = 1;
        foreach (var race in races)
        {
            if (race.possiblities.HasValue)
            {
                product *= race.possiblities.Value;
            }
        }
        Console.WriteLine($"Product of possiblities: {product}");
    }
}



