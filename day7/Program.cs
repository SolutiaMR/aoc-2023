namespace day7;

class Program
{
    public class SpecialComparer : IComparer<Hand>
    {
        public int Compare(Hand h1, Hand h2)
        {
            var handLength = h1.cards.Count();

            for (var i = 0; i < handLength; i++)
            {
                var card1 = h1.cards[i];
                var card2 = h2.cards[i];

                if (card1 < 0)
                {
                    return -1;
                }
                if (card2 < 0)
                {
                    return 1;
                }
                if (card1 > card2)
                {
                    return 1;
                }
                else if (card1 < card2)
                {
                    return -1;
                }
            }
            return 1;
        }
    }
    public class Hand
    {
        public Hand(string cardsString, int bet)
        {
            var cards = new List<int>();
            var newCardList = new List<int>();
            foreach (var card in cardsString)
                cards.Add(cardHierarchy[card.ToString()]);

            if (cardsString.Contains("J"))
            {
                var mostFrequentCard = cards

                            .Where(card => card != -1)
                            .GroupBy(card => card)
                            .OrderByDescending(group => group.Count())
                            .Select(group => group.Key)
                            .FirstOrDefault();

                //join this.cards array into a string and replace all -1's with -1 * cardval

                var newCardString = string.Join("", cards).Replace("-1", mostFrequentCard.ToString());
                foreach (var cardl in newCardString)
                {
                    newCardList.Add(int.Parse(cardl.ToString()));
                }


            }

            this.cards = newCardList;
            this.bet = bet;

        }
        private Dictionary<string, int> handHierarchy = new Dictionary<string, int>(){
            {"5OfAKind", 7},
            {"4OfAKind", 6},
            {"FullHouse", 5},
            {"3OfAKind", 4},
            {"2Pair", 3},
            {"Pair", 2},
            {"HighCard", 1}
        };

        private Dictionary<string, int> cardHierarchy = new Dictionary<string, int>(){

            {"2", 1},
            {"3", 2},
            {"4", 3},
            {"5", 4},
            {"6", 5},
            {"7", 6},
            {"8", 7},
            {"9", 8},
            {"T", 9},
            {"J", -1},
            {"Q", 11},
            {"K", 12},
            {"A", 13}
        };

        public List<int> cards { get; set; }
        public int bet { get; set; }

        public int rank { get; set; } = 0;

        public int getHandResult()
        {
            if (is5OfAKind())
            {
                return handHierarchy["5OfAKind"];
            }
            else if (is4OfAKind())
            {
                return handHierarchy["4OfAKind"];
            }
            else if (isFullHouse())
            {
                return handHierarchy["FullHouse"];
            }
            else if (is3OfAKind())
            {
                return handHierarchy["3OfAKind"];
            }
            else if (is2Pair())
            {
                return handHierarchy["2Pair"];
            }
            else if (isPair())
            {
                return handHierarchy["Pair"];
            }
            else
            {
                return handHierarchy["HighCard"];
            }
        }

        public bool is5OfAKind()
        {
            return cards.DistinctBy(x => Math.Abs(x)).Count() == 1;
        }
        public bool is4OfAKind()
        {
            var groups = cards.GroupBy(x => Math.Abs(x)).ToList();
            if (groups.Any(x => x.Count() == 4))
            {
                return true;
            }
            return false;
        }


        public bool isFullHouse()
        {
            var groups = cards.GroupBy(x => Math.Abs(x)).ToList();

            if (groups.Any(x => x.Count() == 3))
            {
                if (groups.Any(x => x.Count() == 2))
                {
                    return true;
                }
            }
            return false;
        }
        public bool is3OfAKind()
        {
            var groups = cards.GroupBy(x => Math.Abs(x)).ToList();

            if (groups.Any(x => x.Count() == 3) && this.isFullHouse() == false)
            {
                return true;
            }
            return false;
        }
        public bool is2Pair()
        {
            var groups = cards.GroupBy(x => Math.Abs(x)).ToList();

            var oneGroup = groups.Where(x => x.Count() == 2);
            if (oneGroup.Count() == 2)
            {
                return true;
            }

            return false;
        }
        public bool isPair()
        {
            var groups = cards.GroupBy(x => Math.Abs(x)).ToList();

            if (groups.Count() == 4 && groups.Any(x => x.Count() == 2))
            {
                return true;
            }
            return false;
        }
        public bool isHighCard()
        {
            var groups = cards.GroupBy(x => Math.Abs(x)).ToList();

            if (groups.Count() == 5)
            {
                return true;
            }
            return false;
        }

        public int GetHandValue()
        {
            if (is5OfAKind())
            {
                return handHierarchy["5OfAKind"];
            }
            else if (is4OfAKind())
            {
                return handHierarchy["4OfAKind"];
            }
            else if (isFullHouse())
            {
                return handHierarchy["FullHouse"];
            }
            else if (is3OfAKind())
            {
                return handHierarchy["3OfAKind"];
            }
            else if (is2Pair())
            {
                return handHierarchy["2Pair"];
            }
            else if (isPair())
            {
                return handHierarchy["Pair"];
            }
            else
            {
                return handHierarchy["HighCard"];
            }




        }
        public int getHand()
        {
            int combinedValue = int.Parse(string.Join("", this.cards));
            return combinedValue;
        }

        public int GetCardValue(string card)
        {
            return cardHierarchy[card];
        }
    }
    static void Main(string[] args)
    {
        //PartOne();
        PartTwo();
    }

    public static void PartOne()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();

        var hands = new List<Hand>();
        foreach (var line in lines)
        {
            var cards = line.Split(" ")[0];
            var bet = line.Split(" ")[1];
            var hand = new Hand(cards, int.Parse(bet));
            hands.Add(hand);
        }

        var fiveKind = hands.Where(x => x.is5OfAKind()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var foursKind = hands.Where(x => x.is4OfAKind()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var fullHouse = hands.Where(x => x.isFullHouse()).ToList().OrderByDescending(x => x, new SpecialComparer()).ToList();
        var threekind = hands.Where(x => x.is3OfAKind()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var two = hands.Where(x => x.is2Pair()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var onePair = hands.Where(x => x.isPair()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var high = hands.Where(x => x.isHighCard()).OrderByDescending(x => x, new SpecialComparer()).ToList();


        var numberOfHands = hands.Count();
        var masterHands = fiveKind;
        masterHands.AddRange(foursKind);
        masterHands.AddRange(fullHouse);
        masterHands.AddRange(threekind);
        masterHands.AddRange(two);
        masterHands.AddRange(onePair);
        masterHands.AddRange(high);
        var product = 0;
        for (var i = 0; i < numberOfHands; i++)
        {
            var hand = masterHands[(masterHands.Count() - 1) - i];

            product = product + hand.bet * (i + 1);
        }
        // too low 250075001
        Console.WriteLine(product);
    }

    public static void PartTwo()
    {
        var fileProcessor = new FileProcessor("input.txt");
        var lines = fileProcessor.ReadFile();

        var hands = new List<Hand>();
        foreach (var line in lines)
        {
            var cards = line.Split(" ")[0];
            var bet = line.Split(" ")[1];
            var hand = new Hand(cards, int.Parse(bet));
            hands.Add(hand);
        }

        var fiveKind = hands.Where(x => x.is5OfAKind()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var foursKind = hands.Where(x => x.is4OfAKind()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var fullHouse = hands.Where(x => x.isFullHouse()).ToList().OrderByDescending(x => x, new SpecialComparer()).ToList();
        var threekind = hands.Where(x => x.is3OfAKind()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var two = hands.Where(x => x.is2Pair()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var onePair = hands.Where(x => x.isPair()).OrderByDescending(x => x, new SpecialComparer()).ToList();
        var high = hands.Where(x => x.isHighCard()).OrderByDescending(x => x, new SpecialComparer()).ToList();

        var numberOfHands = hands.Count();
        var masterHands = fiveKind;
        masterHands.AddRange(foursKind);
        masterHands.AddRange(fullHouse);
        masterHands.AddRange(threekind);
        masterHands.AddRange(two);
        masterHands.AddRange(onePair);
        masterHands.AddRange(high);
        var product = 0;
        for (var i = 0; i < numberOfHands; i++)
        {
            var hand = masterHands[(masterHands.Count() - 1) - i];

            product = product + hand.bet * (i + 1);
        }
        // too high 251516636
        // 251158614 incorrect
        // 251158614
        // 251158614
        // 250829246
        // 251158614
        Console.WriteLine(product);


    }
}
