namespace day5;

class Program
{

    public class Map()
    {
        public Map(string[] instructions)
        {
            destinationRangeStart = instructions[0];
            sourceRangeStart = instructions[1];
            rangeLength = instructions[2];
        }
        public int destinationRangeStart { get; set; }
        public int sourceRangeStart { get; set; }
        public int rangeLength { get; set; }
    }
    static void Main(string[] args)
    {
        //these are backwards
        PartOne();
        PartTwo();
    }

    public static void PartOne()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();
        //map key in input to a dictionary of keys to hold 
        Dictionary<string, int> keyNames = new Dictionary<string, string>();
        keyNames.Add("seed-to-soil map:", "s2s");
        keyNames.Add("soil-to-fertilizer map:", "s2f");
        keyNames.Add("fertilizer-to-water map:", "f2w");
        keyNames.Add("water-to-light map:", "w2l");
        keyNames.Add("light-to-temperature map:", "l2t");
        keyNames.Add("temperature-to-humidity map:", "t2h");
        keyNames.Add("humidity-to-location: map", "h2l");
        List<int> seedsToPlant = new List<int>();
        var stringSeeds = lines[0].Split(":")[1];

        foreach (var seed in stringSeeds.Split(' '))
        {
            if (seed.ToString() != "")
            {
                seedsToPlant.Add(int.Parse(seed.ToString()));
            }
        }
        var current
        foreach (var line in lines)
        {
            if (line.Contains("seeds:"))
                continue;
            while (line != "")
            {

            }
        }

    }
    public static void PartTwo()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();

    }
}