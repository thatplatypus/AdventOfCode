using Day1 = AdventOfCode2023.Day1;
using Day2 = AdventOfCode2023.Day2;

var input = await File.ReadAllLinesAsync("Day2/Input.txt");

//var result = Day1.Solution.Solve(input);
//var result = Day1.Solution.Solve_Part2(input);

var result = Day2.Solution.Solve(input);
//var result = Day2.Solution.Solve_Part2(input);

Console.WriteLine(result);

Console.ReadLine();