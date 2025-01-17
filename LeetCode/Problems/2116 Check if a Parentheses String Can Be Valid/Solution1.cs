namespace LeetCode.Problems._2116_Check_if_a_Parentheses_String_Can_Be_Valid;

/// <summary>
/// https://leetcode.com/submissions/detail/1505585533/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CanBeValid(string s, string locked)
    {
        var n = s.Length;

        var balance = 0;
        var unlockedIndices = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var isUnlocked = locked[i] == '0';

            if (isUnlocked)
            {
                unlockedIndices.Add(i);
            }

            var diff = 0 switch
            {
                _ when isUnlocked => 1,
                _ when s[i] == '(' => 1,
                _ => -1
            };

            balance += diff;
            if (balance < 0)
            {
                return false;
            }
        }

        if (balance % 2 == 1)
        {
            return false;
        }

        var flipCount = balance / 2;

        if (flipCount > unlockedIndices.Count)
        {
            return false;
        }

        var indicesToFlip = unlockedIndices.Skip(unlockedIndices.Count - flipCount).ToHashSet();

        for (var i = 0; i < n; i++)
        {
            var isUnlocked = locked[i] == '0';

            var diff = 0 switch
            {
                _ when indicesToFlip.Contains(i) => -1,
                _ when isUnlocked => 1,
                _ when s[i] == '(' => 1,
                _ => -1
            };

            balance += diff;

            if (balance < 0)
            {
                return false;
            }
        }

        return true;
    }
}
