using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day3
{
    /// <summary>
    /// https://adventofcode.com/2023/day/3
    /// </summary>
    public partial class Solution
    {
        
        public static int Solve(IEnumerable<string> input)
        {
            int result = 0;
            var grid = input.Select(x => x.ToCharArray()).ToArray();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (char.IsDigit(grid[i][j]))
                    {
                        int start = j;
                        while (j < grid[i].Length && char.IsDigit(grid[i][j]))
                        {
                            j++;
                        }

                        int num = int.Parse(new string(grid[i], start, j - start));
                        if (!IsDanglingPart(grid, i, start, j - 1))
                        {
                            result += num;
                        }
                    }
                }
            }

            return result;
        }  

        public static long Solve_Part2(IEnumerable<string> input)
        {
            List<Part> parts = [];
            List<Gear> gears = [];
            long result = 0;
            int y = 0;

            foreach (string line in input)
            {
                foreach (Match match in AllParts().Matches(line).Cast<Match>())
                {
                    parts.Add(new Part
                    {
                        PartNumber = int.Parse(match.Value),
                        Y = y,
                        X = match.Index,
                        Length = match.Length
                    });
                }

                foreach (Match match in AllGears().Matches(line).Cast<Match>())
                {
                    gears.Add(new Gear { X = match.Index, Y = y });
                }

                y++;
            }

            foreach (var gear in gears)
            {
                var nearbyParts = parts.Where(part => part.IsNearby(gear.X, gear.Y)).ToList();
                if (nearbyParts.Count == 2)
                {
                    result += nearbyParts[0].PartNumber * nearbyParts[1].PartNumber;
                }
            }

            return result;
        }

        private static bool IsDanglingPart(char[][] grid, int i, int sj, int ej)
        {
            int[] dx = [-1, 0, 1, 0, -1, -1, 1, 1];
            int[] dy = [0, 1, 0, -1, -1, 1, -1, 1];

            for (int j = sj; j <= ej; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    int ni = i + dx[k], nj = j + dy[k];
                    if (ni >= 0 && ni < grid.Length && nj >= 0 && nj < grid[0].Length)
                    {
                        if (grid[ni][nj] != '.' && !(ni == i && nj >= sj && nj <= ej))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        [GeneratedRegex(@"\d+")]
        private static partial Regex AllParts();
        [GeneratedRegex(@"\*")]
        private static partial Regex AllGears();

        partial struct Part
        {
            public int X;
            public int Y;
            public int Length;
            public int PartNumber;

            public readonly bool IsNearby(int symbolX, int symbolY)
            {
                if (symbolY < (Y - 1) || symbolY > (Y + 1)) return false;
                return Enumerable.Range(X - 1, Length + 2).Contains(symbolX);
            }
        };

        partial struct Gear
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
