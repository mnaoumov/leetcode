namespace LeetCode.Problems._3014_Minimum_Number_of_Pushes_to_Type_Word_I;

/// <seealso href="https://leetcode.com/contest/weekly-contest-381/submissions/detail/1152133096/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumPushes(string word)
    {
        var length = word.Length;

        const int buttonsCount = 8;

        var ans = 0;
        var pushesCount = 1;

        while (length > 0)
        {
            var assignments = Math.Min(length, buttonsCount);
            length -= assignments;
            ans += pushesCount * assignments;
            pushesCount++;
        }

        return ans;
    }
}
