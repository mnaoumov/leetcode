using JetBrains.Annotations;

namespace LeetCode.Problems._1081_Smallest_Subsequence_of_Distinct_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/1061019350/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SmallestSubsequence(string s)
    {
        var lastIndexMap = new Dictionary<char, int>();

        var n = s.Length;

        for (var i = 0; i < n; i++)
        {
            lastIndexMap[s[i]] = i;
        }

        var stack = new Stack<char>();
        var usedLetters = new HashSet<char>();

        for (var i = 0; i < n; i++)
        {
            var letter = s[i];

            if (!usedLetters.Add(letter))
            {
                continue;
            }

            while (stack.Count > 0)
            {
                var previousLetter = stack.Peek();

                if (previousLetter < letter || lastIndexMap[previousLetter] < i)
                {
                    break;
                }

                usedLetters.Remove(previousLetter);
                stack.Pop();
            }

            stack.Push(letter);
        }

        return string.Concat(stack.Reverse());
    }
}
