namespace day3;
using System.Text.RegularExpressions;

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
        var specialCharPosition = new HashSet<int[]>();

        var possibleNumPosition = new HashSet<int[]>();

        possibleNumPosition.Add(new int[] { 0, -1 }); //left
        possibleNumPosition.Add(new int[] { 0, 1 }); //right
        possibleNumPosition.Add(new int[] { -1, 0 }); //up
        possibleNumPosition.Add(new int[] { 1, 0 }); //down
        possibleNumPosition.Add(new int[] { -1, 1 }); //up right
        possibleNumPosition.Add(new int[] { -1, -1 }); //up right
        possibleNumPosition.Add(new int[] { 1, 1 }); //down right
        possibleNumPosition.Add(new int[] { 1, -1 }); // down left

        var usedPositions = new List<int[]>();

        var numbas = new List<int>();
        string pattern = @"[^a-zA-Z0-9\s.]";
        Regex rgx = new Regex(pattern);
        var idx = 0;
        var charIdx = 0;
        //get all special char positions
        foreach (var line in lines)
        {
            charIdx = 0;
            foreach (var c in line)
            {
                if (rgx.IsMatch(c.ToString()))
                {
                    specialCharPosition.Add(new int[] { idx, charIdx });
                }
                charIdx += 1;
            }
            idx += 1;
        }
        foreach (var pos in specialCharPosition)
        {
            foreach (var borderingChar in possibleNumPosition)
            {
                int row = pos[0] + borderingChar[0];
                int col = pos[1] + borderingChar[1];


                if (row < 0 || row > lines.Length - 1 || col < 0 || col > lines[row].Length - 1)
                {
                    Console.WriteLine("Out of bounds");
                    continue;
                }
                if (usedPositions.Any(x => x[0] == row && x[1] == col))
                {
                    Console.WriteLine("Already used");
                    continue;
                }
                var numString = "";
                if (int.TryParse(lines[row][col].ToString(), out int number))
                {
                    usedPositions.Add([row, col]);
                    numString = number.ToString();
                    var rightIdx = 1;
                    var leftIdx = -1;

                    while (rightIdx + col <= lines[row].Length - 1 && int.TryParse(lines[row][col + rightIdx].ToString(), out int rightNumber))
                    {
                        if (usedPositions.Any(x => x[0] == row && x[1] == col + rightIdx))
                        {
                            Console.WriteLine("Already used");
                            break;
                        }
                        usedPositions.Add([row, col + rightIdx]); // down left
                        numString = numString + rightNumber.ToString();
                        rightIdx = rightIdx + 1;

                    }
                    while (col + leftIdx >= 0 && int.TryParse(lines[row][col + leftIdx].ToString(), out int leftNumber))
                    {
                        Console.WriteLine("going left " + leftNumber.ToString());
                        if (usedPositions.Any(x => x[0] == row && x[1] == col + leftIdx))
                        {
                            Console.WriteLine("Already used");
                            break;
                        }
                        usedPositions.Add([row, col + leftIdx]); // down left
                        numString = leftNumber.ToString() + numString;
                        leftIdx = leftIdx - 1;
                    }

                }
                if (numString != "")
                {
                    numbas.Add(int.Parse(numString));
                    Console.WriteLine(numString);
                }


                // Access the row and col values and perform your desired operations
                // ...


            }
        }

        Console.WriteLine(numbas.Sum());
        // Console.WriteLine(int.Parse(first.ToString() + second.ToString() + third.ToString()));
        // numList.Add(int.Parse(first.ToString() + second.ToString() + third.ToString()));
    }
    public static void PartTwo()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();
        var specialCharPosition = new HashSet<int[]>();

        var possibleNumPosition = new HashSet<int[]>();

        possibleNumPosition.Add(new int[] { 0, -1 }); //left
        possibleNumPosition.Add(new int[] { 0, 1 }); //right
        possibleNumPosition.Add(new int[] { -1, 0 }); //up
        possibleNumPosition.Add(new int[] { 1, 0 }); //down
        possibleNumPosition.Add(new int[] { -1, 1 }); //up right
        possibleNumPosition.Add(new int[] { -1, -1 }); //up right
        possibleNumPosition.Add(new int[] { 1, 1 }); //down right
        possibleNumPosition.Add(new int[] { 1, -1 }); // down left

        var usedPositions = new List<int[]>();

        var numbas = new List<int>();
        string pattern = @"[^a-zA-Z0-9\s.]";
        Regex rgx = new Regex(pattern);
        var idx = 0;
        var charIdx = 0;
        //get all special char positions
        foreach (var line in lines)
        {
            charIdx = 0;
            foreach (var c in line)
            {
                if (rgx.IsMatch(c.ToString()))
                {
                    specialCharPosition.Add(new int[] { idx, charIdx });
                }
                charIdx += 1;
            }
            idx += 1;
        }
        foreach (var pos in specialCharPosition)
        {
            var hits = 0;
            var gears = new List<int>();
            foreach (var borderingChar in possibleNumPosition)
            {
                int row = pos[0] + borderingChar[0];
                int col = pos[1] + borderingChar[1];


                if (row < 0 || row > lines.Length - 1 || col < 0 || col > lines[row].Length - 1)
                {
                    Console.WriteLine("Out of bounds");
                    continue;
                }
                if (usedPositions.Any(x => x[0] == row && x[1] == col))
                {
                    Console.WriteLine("Already used");
                    continue;
                }
                var numString = "";
                if (int.TryParse(lines[row][col].ToString(), out int number))
                {
                    usedPositions.Add([row, col]);
                    numString = number.ToString();
                    var rightIdx = 1;
                    var leftIdx = -1;

                    Console.WriteLine("RightIdx" + rightIdx);
                    Console.WriteLine("Row" + row);
                    Console.WriteLine("Col" + col);
                    Console.WriteLine(lines[row].Length - 1);
                    while (rightIdx + col <= lines[row].Length - 1 && int.TryParse(lines[row][col + rightIdx].ToString(), out int rightNumber))
                    {
                        if (usedPositions.Any(x => x[0] == row && x[1] == col + rightIdx))
                        {
                            Console.WriteLine("Already used");
                            break;
                        }
                        usedPositions.Add([row, col + rightIdx]); // down left
                        numString = numString + rightNumber.ToString();
                        rightIdx = rightIdx + 1;

                    }
                    while (col + leftIdx >= 0 && int.TryParse(lines[row][col + leftIdx].ToString(), out int leftNumber))
                    {
                        Console.WriteLine("going left " + leftNumber.ToString());
                        if (usedPositions.Any(x => x[0] == row && x[1] == col + leftIdx))
                        {
                            Console.WriteLine("Already used");
                            break;
                        }
                        usedPositions.Add([row, col + leftIdx]); // down left
                        numString = leftNumber.ToString() + numString;
                        leftIdx = leftIdx - 1;
                    }


                }
                if (numString != "")
                {
                    gears.Add(int.Parse(numString));
                }


                // Access the row and col values and perform your desired operations
                // ...


            }
            if (gears.Count == 2)
            {
                numbas.Add(gears[0] * gears[1]);
            }
        }

        Console.WriteLine(numbas.Sum());
        // Console.WriteLine(int.Parse(first.ToString() + second.ToString() + third.ToString()));
        // numList.Add(int.Parse(first.ToString() + second.ToString() + third.ToString()));
    }
}







// int skip = 0;
// foreach(var c, charIdx = 0 in line)
// {
//     if(skip > 0)
//     {
//         skip--;
//         continue;
//     }
//     //if we can parse the character as an int, we know it's a number, check grid around it for special char
//     if(int.TryParse(c.ToString(), out int number))
//     {
//         int firstDigit = number;
//         //try to parse two digits after 
//         if(charIdx != lines.Length - 1 && int.TryParse(lines[charIdx + 1].ToString(), out int secondDigit))
//         {
//             number = int.Parse(number.ToString() + secondDigit.ToString());
//             skip = 1;
//         }
//         if(charIdx != lines.Length - 2 && int.TryParse(lines[charIdx + 2].ToString(), out int thirdDigit))
//         {
//             number = int.Parse(firstDigit.ToString() + secondDigit.ToString() + thirdDigit().ToString());
//             skip = 2;
//         }

//     }