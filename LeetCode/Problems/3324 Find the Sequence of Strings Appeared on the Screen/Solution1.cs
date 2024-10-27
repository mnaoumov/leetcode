namespace LeetCode.Problems._3324_Find_the_Sequence_of_Strings_Appeared_on_the_Screen;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-420/submissions/detail/1427828464/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> StringSequence(string target)
    {
        var ans = new List<string>();
        var prefix = "";

        foreach (var letter in target)
        {
            for (var newLetter = 'a'; newLetter <= letter; newLetter++)
            {
                ans.Add(prefix + newLetter);
            }
            prefix += letter;
        }
        return ans;
    }
}
