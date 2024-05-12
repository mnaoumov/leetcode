using System.Text;
using JetBrains.Annotations;

namespace LeetCode.Problems._1415_The_k_th_Lexicographical_String_of_All_Happy_Strings_of_Length_n;

/// <summary>
/// https://leetcode.com/submissions/detail/919046086/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string GetHappyString(int n, int k)
    {
        var counter = 0;
        var happyStringBuilder = new StringBuilder();
        var letters = new[] { 'a', 'b', 'c' };
        return Backtrack();

        string Backtrack()
        {
            if (happyStringBuilder.Length == n)
            {
                counter++;
                return counter == k ? happyStringBuilder.ToString() : "";
            }

            foreach (var letter in letters)
            {
                if (happyStringBuilder.Length > 0 && happyStringBuilder[^1] == letter)
                {
                    continue;
                }

                happyStringBuilder.Append(letter);
                var result = Backtrack();
                happyStringBuilder.Remove(happyStringBuilder.Length - 1, 1);

                if (result != "")
                {
                    return result;
                }
            }

            return "";
        }
    }
}
