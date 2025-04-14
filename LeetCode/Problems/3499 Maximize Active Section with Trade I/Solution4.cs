namespace LeetCode.Problems._3499_Maximize_Active_Section_with_Trade_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-153/problems/maximize-active-section-with-trade-i/submissions/1590159513/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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
        
        var ans = 0;

        for (var i = 0; i < sectionLengths.Count; i += 2)
        {
            ans += sectionLengths[i];
        }

        if (sectionLengths.Count < 5)
        {
            return ans;
        }

        ans += sectionLengths[1] + sectionLengths[3];
        var movingAns = ans;

        for (var i = 5; i < sectionLengths.Count; i += 2)
        {
            movingAns += sectionLengths[i] - sectionLengths[i - 4];
            ans = Math.Max(ans, movingAns);
        }

        return ans;
    }
}
