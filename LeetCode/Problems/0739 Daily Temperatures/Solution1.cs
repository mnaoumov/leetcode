using JetBrains.Annotations;

namespace LeetCode.Problems._0739_Daily_Temperatures;

/// <summary>
/// https://leetcode.com/submissions/detail/861350595/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var answer = new int[temperatures.Length];

        var stack = new Stack<int>();

        for (var index = 0; index < temperatures.Length; index++)
        {
            while (stack.TryPeek(out var previousIndex) && temperatures[previousIndex] < temperatures[index])
            {
                stack.Pop();
                answer[previousIndex] = index - previousIndex;
            }

            stack.Push(index);
        }

        return answer;
    }
}
