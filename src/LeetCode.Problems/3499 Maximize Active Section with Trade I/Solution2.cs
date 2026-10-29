namespace LeetCode.Problems._3499_Maximize_Active_Section_with_Trade_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-153/problems/maximize-active-section-with-trade-i/submissions/1590140805/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxActiveSectionsAfterTrade(string s)
    {
        const char inactive = '0';
        const char active = '1';

        var sectionLengths = new List<int> { 0 };

        foreach (var state in s)
        {
            var previousState = sectionLengths.Count % 2 == 1 ? active : inactive;
            if (state == previousState)
            {
                sectionLengths[^1]++;
            }
            else
            {
                sectionLengths.Add(1);
            }
        }

        if (sectionLengths.Count % 2 == 0)
        {
            sectionLengths.Add(0);
        }


        int sum;

        if (sectionLengths.Count < 5)
        {
            sum = 0;
            for (var i = 0; i < sectionLengths.Count; i += 2)
            {
                sum += sectionLengths[i];
            }

            return sum;
        }

        sum = sectionLengths.Take(5).Sum();
        var ans = sum;

        for (var i = 6; i < sectionLengths.Count; i += 2)
        {
            sum += sectionLengths[i - 1] + sectionLengths[i] - sectionLengths[i - 5] - sectionLengths[i - 4];
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}
