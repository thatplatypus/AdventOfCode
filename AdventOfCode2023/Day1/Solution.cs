
namespace AdventOfCode2023.Day1
{
    /// <summary>
    /// https://adventofcode.com/2023/day/1
    /// On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.
    /// </summary>
    public static class Solution
    {
        /// <summary>
        /// Simple parse with indexes on left and right to find the first and last occurring numbers
        /// Then string "calibration" to get the sum
        /// </summary>
        public static int Solve(IEnumerable<string> input)
        {
            int answer = 0;

            foreach (string s in input)
            {
                bool foundLeft = false;
                bool foundRight = false;
                int startPtr = 0;
                int endPtr = s.Length-1;
                string leftNum = "";
                string rightNum = "";

                while(!foundLeft || !foundRight) 
                {
                    if (!foundLeft && int.TryParse(s[startPtr] + "", out int leftResult))
                    {
                        foundLeft = true;
                        leftNum = leftResult + "";
                    }

                    if (!foundRight && int.TryParse(s[endPtr] + "", out int rightResult))
                    {
                        foundRight = true;
                        rightNum = rightResult + "";
                    }

                    if (foundLeft && foundRight)
                    {
                        if(int.TryParse(leftNum + rightNum, out int result))
                            answer += result;
                        
                        break;
                    }

                    if (!foundLeft)
                        startPtr++;

                    if(!foundRight)
                        endPtr--;
                }
            }

            return answer;
        }

        /// <summary>
        /// To avoid tokenizing the string, replace things that look like numbers with their number
        /// But also leave the edges for any other numbers that were sharing a letter
        /// </summary>
        public static int Solve_Part2(IEnumerable<string> input)
        {
            return Solve(input.Select(x =>
                x.Replace("one", "o1e")
                .Replace("two", "t2o")
                .Replace("three", "t3e")
                .Replace("four", "f4r")
                .Replace("five", "f5e")
                .Replace("six", "s6x")
                .Replace("seven", "s7n")
                .Replace("eight", "e8t")
                .Replace("nine", "n9e")
                ));
        }
    }
}
