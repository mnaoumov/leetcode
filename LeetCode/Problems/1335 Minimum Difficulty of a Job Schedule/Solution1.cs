using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._1335_Minimum_Difficulty_of_a_Job_Schedule;

/// <summary>
/// https://leetcode.com/submissions/detail/823332607/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        const int impossible = -1;

        if (jobDifficulty.Length < d)
        {
            return impossible;
        }

        if (jobDifficulty.Length == d)
        {
            return jobDifficulty.Sum();
        }

        var dp = new int?[jobDifficulty.Length, d + 1];

        return Cut(0, 1);

        int Cut(int firstJobIndex, int currentDayNumber)
        {
            if (dp[firstJobIndex, currentDayNumber] is not { } result)
            {
                dp[firstJobIndex, currentDayNumber] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (currentDayNumber == d)
                {
                    return jobDifficulty.Skip(firstJobIndex).Max();
                }

                var currentDayDifficulty = int.MinValue;
                var minDifficultyStartingFromToday = int.MaxValue;

                for (int i = firstJobIndex; i < jobDifficulty.Length - d + currentDayNumber; i++)
                {
                    currentDayDifficulty = Math.Max(currentDayDifficulty, jobDifficulty[i]);
                    var difficultyAfterToday = Cut(i + 1, currentDayNumber + 1);
                    minDifficultyStartingFromToday = Math.Min(minDifficultyStartingFromToday, currentDayDifficulty + difficultyAfterToday);
                }

                return minDifficultyStartingFromToday;
            }
        }
    }
}
