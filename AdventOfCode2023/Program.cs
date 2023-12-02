using AdventOfCode2023.Day1;

var input = await File.ReadAllLinesAsync("Day1/input.txt");

var result = Solution.Solve_Part2(input);

Console.WriteLine(result);

Console.ReadLine();