namespace LeetCode.Problems._0458_Poor_Pigs;

/// <seealso href="https://leetcode.com/submissions/detail/1086992392/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
    {
        var tests = minutesToTest / minutesToDie;
        var ans = (int) Math.Log(buckets, tests + 1);
        if (Math.Pow(tests + 1, ans) < buckets)
        {
            ans++;
        }
        return ans;
    }
}
