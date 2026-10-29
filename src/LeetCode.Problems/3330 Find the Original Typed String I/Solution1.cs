namespace LeetCode.Problems._3330_Find_the_Original_Typed_String_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-142/submissions/detail/1434276647/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PossibleStringCount(string word)
    {
        var groupSizes = new List<int> { 1 };

        for (var i = 1; i < word.Length; i++)
        {
            if (word[i] == word[i - 1])
            {
                groupSizes[^1]++;
            }
            else
            {
                groupSizes.Add(1);
            }
        }

        return 1 + word.Length - groupSizes.Count;
    }
}
