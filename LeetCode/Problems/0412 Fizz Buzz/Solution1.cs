using JetBrains.Annotations;

namespace LeetCode._0412_Fizz_Buzz;

/// <summary>
/// https://leetcode.com/problems/fizz-buzz/submissions/845588599/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> FizzBuzz(int n) => Enumerable.Range(1, n).Select(ToFizzBuzzString).ToArray();

    private static string ToFizzBuzzString(int num) => num % 15 == 0 ? "FizzBuzz" : num % 3 == 0 ? "Fizz" : num % 5 == 0 ? "Buzz" : num.ToString();
}
