namespace day1;
class Program
{
    static void Main(string[] args)
    {
        PartOne();
        PartTwo();
    }

    public static void PartOne()
    {
        var fileProcessor = new FileProcessor("input.txt");
        string[] lines = fileProcessor.ReadFile();
        List<int> numbers = new List<int>();
        foreach (string line in lines)
        {
            int? first = null;
            int? last = null;
            foreach (var c in line)
            {
                if (int.TryParse(c.ToString(), out int number))
                {
                    if (first == null)
                    {
                        first = number;
                    }
                    last = number;
                }
            }
            if (first != null && last != null)
            {
                numbers.Add(int.Parse(first.ToString() + last.ToString()));
            }
        }



        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        Console.WriteLine(total);
    }

    public static void PartTwo()
    {
        List<string> digitStrings = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];


        var fileProcessor = new FileProcessor("input.txt");
        string[] lines = fileProcessor.ReadFile();
        List<int> numbers = new List<int>();
        foreach (string line in lines)
        {
            int? first = null;
            int? last = null;
            foreach (var c in line)
            {
                if (int.TryParse(c.ToString(), out int number))
                {
                    if (first == null)
                    {
                        first = number;
                    }
                    last = number;
                }
            }

            //first number
            //last number 

            var lastDigitString = "";
            var firstDigitString = "";

            foreach (var digitString in digitStrings)
            {

                if (line.Contains(digitString) && (line.IndexOf(digitString) <= line.IndexOf(first.ToString()) || line.IndexOf(first.ToString()) == -1))
                {
                    if (firstDigitString == "" || line.IndexOf(digitString) <= line.IndexOf(firstDigitString.ToString()))
                    {

                        first = digitStrings.IndexOf(digitString) + 1;
                        firstDigitString = digitString;
                    }
                }
                if (line.Contains(digitString) && (line.LastIndexOf(digitString) >= (line.LastIndexOf(last.ToString())) || line.LastIndexOf(last.ToString()) == -1))

                {
                    if (lastDigitString == "" || (line.LastIndexOf(digitString.ToString()) >= line.LastIndexOf(lastDigitString.ToString())))
                    {
                        last = digitStrings.IndexOf(digitString) + 1;
                        lastDigitString = digitString;
                    }
                }
            }
            Console.WriteLine($"{first} {last}");
            numbers.Add(int.Parse(first.ToString() + last.ToString()));

        }



        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        Console.WriteLine(total);
    }
}
