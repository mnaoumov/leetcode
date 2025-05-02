namespace LeetCode.Problems._3522_Calculate_Score_After_Performing_Instructions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-446/problems/calculate-score-after-performing-instructions/submissions/1611999660/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CalculateScore(string[] instructions, int[] values)
    {
        var ans = 0L;

        var n = instructions.Length;

        var index = 0;
        var visitedIndices = new HashSet<int>();

        while (true)
        {
            if (index < 0 || index >= n)
            {
                break;
            }

            if (!visitedIndices.Add(index))
            {
                break;
            }

            var value = values[index];

            switch (instructions[index])
            {
                case "add":
                    ans += value;
                    index++;
                    break;
                case "jump":
                    index += value;
                    break;
            }
        }

        return ans;
    }
}
