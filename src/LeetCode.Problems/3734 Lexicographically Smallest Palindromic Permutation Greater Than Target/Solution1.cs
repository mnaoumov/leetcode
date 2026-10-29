using System.Text;

namespace LeetCode.Problems._3734_Lexicographically_Smallest_Palindromic_Permutation_Greater_Than_Target;

/// <summary>
/// https://leetcode.com/problems/lexicographically-smallest-palindromic-permutation-greater-than-target/submissions/2122516908/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LexPalindromicPermutation(string s, string target)
    {
        var letterCounts = s.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        if (letterCounts.Count(kvp => kvp.Value % 2 == 1) > 1)
        {
            return "";
        }

        const char noLetter = '\0';
        var oddCountLetter = letterCounts.Keys.FirstOrDefault(k => letterCounts[k] % 2 == 1, noLetter);

        var n = s.Length;
        var sb = new StringBuilder { Length = n };

        if (oddCountLetter != noLetter)
        {
            sb[n / 2] = oddCountLetter;
            letterCounts[oddCountLetter]--;

            if (letterCounts[oddCountLetter] == 0)
            {
                letterCounts.Remove(oddCountLetter);
            }
        }

        return CanAssignLetter(0, false) ? sb.ToString() : "";

        bool TryAssignLetter(int index, bool isGreaterAlready, char letter)
        {
            sb[index] = letter;
            sb[n - 1 - index] = letter;
            letterCounts[letter] -= 2;
            if (letterCounts[letter] == 0)
            {
                letterCounts.Remove(letter);
            }

            var ans = CanAssignLetter(index + 1, isGreaterAlready);

            if (ans)
            {
                return ans;
            }

            letterCounts.TryAdd(letter, 0);
            letterCounts[letter] += 2;
            return ans;
        }

        bool CanAssignLetter(int index, bool isGreaterAlready)
        {
            if (index == n / 2)
            {
                return isGreaterAlready || sb.ToString().CompareTo(target, StringComparison.Ordinal) > 0;
            }


            if (isGreaterAlready)
            {
                return TryAssignLetter(index, isGreaterAlready, letterCounts.Keys.Min());
            }

            var targetLetter = target[index];

            if (letterCounts.ContainsKey(targetLetter) && TryAssignLetter(index, false, targetLetter))
            {
                return true;
            }

            var nextLetter = letterCounts.Keys.Where(l => l > targetLetter).DefaultIfEmpty(noLetter).Min();
            return nextLetter != noLetter && TryAssignLetter(index, true, nextLetter);
        }
    }
}
