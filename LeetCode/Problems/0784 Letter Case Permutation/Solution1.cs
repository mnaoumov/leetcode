using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0784_Letter_Case_Permutation;

/// <summary>
/// https://leetcode.com/submissions/detail/929400092/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> LetterCasePermutation(string s)
    {
        var result = new List<string>();
        var sb = new StringBuilder();
        Backtrack(0);
        return result;

        void Backtrack(int index)
        {
            if (index == s.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            var symbol = s[index];

            var symbolVariants = char.IsLetter(symbol)
                ? new[] { char.ToUpper(symbol), char.ToLower(symbol) }
                : new[] { symbol };

            foreach (var symbolVariant in symbolVariants)
            {
                sb.Append(symbolVariant);
                Backtrack(index + 1);
                sb.Remove(index, 1);
            }
        }
    }
}
