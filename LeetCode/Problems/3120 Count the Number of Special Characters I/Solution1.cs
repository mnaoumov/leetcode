namespace LeetCode.Problems._3120_Count_the_Number_of_Special_Characters_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-394/submissions/detail/1237785001/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSpecialChars(string word)
    {
        var letters = word.ToHashSet();
        var specialChars = new HashSet<char>();

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var letter in word)
        {
            var lower = char.ToLower(letter);
            var upper = char.ToUpper(letter);

            if (letters.Contains(lower) && letters.Contains(upper))
            {
                specialChars.Add(lower);
            }
        }

        return specialChars.Count;
    }
}
