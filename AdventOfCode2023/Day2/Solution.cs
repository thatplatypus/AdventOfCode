using System.Drawing;

namespace AdventOfCode2023.Day2
{
    /// <summary>
    /// Elf color cube bag game
    /// https://adventofcode.com/2023/day/2
    /// </summary>
    public class Solution
    {
        public static int Solve(IEnumerable<string> input)
        {
            int result = 0;
            List<Dictionary<string, int>> gameTracker = new();
            Dictionary<string, int> controlBag = new()
            {
                { "red",  12 },
                { "green", 13 },
                { "blue", 14}
            };

            ParseGame(gameTracker, input);

            int index = 0;
            gameTracker.ForEach(game =>
            {
                index++;
                bool invalid = false;

                foreach (var key in controlBag.Keys)
                {
                    if (game[key] > controlBag[key])
                        invalid = true;
                }

                if (!invalid)
                    result += index;
            });

            return result;
        }

        public static int Solve_Part2(IEnumerable<string> input)
        {
            int result = 0;
            List<Dictionary<string, int>> gameTracker = new();

            ParseGame(gameTracker, input);

            gameTracker.ForEach(game =>
            {
                result += game["blue"] * game["red"] * game["green"];
            });

            return result;
        }


        public static void ParseGame(List<Dictionary<string, int>> gameTracker, IEnumerable<string> input)
        {
            foreach (var item in input)
            {
                gameTracker.Add([]);

                foreach (var game in item[(item.IndexOf(":") + 1)..].Split(";"))
                {
                    foreach (var colorScore in game.Trim().Split(','))
                    {
                        string arg1 = colorScore.Trim().Split(" ")[0];
                        string arg2 = colorScore.Trim().Split(" ")[1];

                        if (int.TryParse(arg1, out int count))
                            TryAdd(gameTracker.Last(), arg2, count);

                        if (int.TryParse(arg2, out count))
                            TryAdd(gameTracker.Last(), arg1, count);


                    }
                }
            }
        }

        public static void TryAdd(Dictionary<string, int> gameTracker, string key, int count)
        {
            if (gameTracker.ContainsKey(key))
            {
                if (count > gameTracker[key])
                    gameTracker[key] = count;
            }
            else
            {
                gameTracker.Add(key, count);
            }
        }
    }

}