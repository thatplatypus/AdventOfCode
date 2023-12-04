using Day1 = AdventOfCode2023.Day1;
using Day2 = AdventOfCode2023.Day2;
using Day3 = AdventOfCode2023.Day3;


var input = await File.ReadAllLinesAsync("Day3/Input.txt");

//var result = Day1.Solution.Solve(input);
//var result = Day1.Solution.Solve_Part2(input);

//var result = Day2.Solution.Solve(input);
//var result = Day2.Solution.Solve_Part2(input);

//var result = Day3.Solution.Solve(input);
var result = Day3.Solution.Solve_Part2(input);

Console.WriteLine(result);

Console.ReadLine();