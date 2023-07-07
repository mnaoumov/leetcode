using JetBrains.Annotations;

namespace LeetCode._2024_Maximize_the_Confusion_of_an_Exam;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxConsecutiveAnswers(string answerKey, int k)
    {
        var n = answerKey.Length;
        var trueCounts = new int[n + 1];
        const char trueAnswer = 'T';

        for (var i = 0; i < n; i++)
        {
            trueCounts[i + 1] = trueCounts[i] + (answerKey[i] == trueAnswer ? 1 : 0);
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            var z = trueCounts[i + 1] - trueCounts[i - ans];

            if (z >= ans + 1 - k || z <= k)
            {
                ans++;
            }
        }

        return ans;
    }
}
