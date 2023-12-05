namespace day4;

class Program
{
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
        var cards = 0;
        var gameCopies = new Dictionary<int, int>();
        var factor = 0;
        var gameStats = new Dictionary<int, int>();

        var gameIdx = 0;
        foreach (var line in lines)
        {
            gameIdx += 1;
            gameCopies.Add(gameIdx, 1);
        }
        gameIdx = 0;
        foreach (var line in lines)
        {
            gameIdx += 1;
            var lottery = line.Split(':')[1].Trim();
            var champs = lottery.Split('|')[0];
            var myNumbers = lottery.Split('|')[1];
            var winners = 0;
            var winningNums = champs.Split(' ');
            var myNums = myNumbers.Split(' ');

            List<int> myPotentialNumbers = new List<int>();

            foreach (var myNum in myNums)
            {
                if (myNum != "")
                {
                    myPotentialNumbers.Add(Convert.ToInt32(myNum));
                }
            }

            foreach (var num in winningNums)
            {
                if (num != "")
                {
                    var numAsInt = Convert.ToInt32(num);
                    if (myPotentialNumbers.Any(x => x == numAsInt))
                    {
                        winners = winners + 1;
                    }
                }
            }
            var idx = 0;
            while (idx < winners)
            {
                idx += 1;
                Console.WriteLine("Winner! adding a copy to" + (gameIdx + idx) + "from " + gameIdx + " for each copy ( " + gameCopies[gameIdx] + " ) in the copy list");
                var adds = 0;
                while (adds < gameCopies[gameIdx])
                {
                    adds += 1;
                    gameCopies[gameIdx + idx] = gameCopies[gameIdx + idx] + 1;
                }
            }
        }
        foreach (KeyValuePair<int, int> entry in gameCopies)
        {
            cards += entry.Value;
        }
        Console.WriteLine(cards);
    }
    public static void PartTwo()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();
        var points = 0;
        foreach (var line in lines)
        {
            var gamePoints = 0;
            var winners = 0;
            var lottery = line.Split(':')[1].Trim();
            var champs = lottery.Split('|')[0];
            var myNumbers = lottery.Split('|')[1];

            var winningNums = champs.Split(' ');
            var myNums = myNumbers.Split(' ');

            List<int> myPotentialNumbers = new List<int>();

            foreach (var myNum in myNums)
            {
                if (myNum != "")
                {
                    myPotentialNumbers.Add(Convert.ToInt32(myNum));
                }
            }

            foreach (var num in winningNums)
            {
                if (num != "")
                {
                    var numAsInt = Convert.ToInt32(num);
                    if (myPotentialNumbers.Any(x => x == numAsInt))
                    {
                        winners = winners + 1;
                    }
                }
            }
            var idx = 0;
            while (idx < winners)
            {
                idx += 1;
                if (gamePoints == 0)
                {
                    gamePoints = gamePoints + 1;
                }
                else
                {
                    gamePoints = gamePoints * 2;
                }
            }

            points += gamePoints;
        }
        Console.WriteLine(points);
    }
}
