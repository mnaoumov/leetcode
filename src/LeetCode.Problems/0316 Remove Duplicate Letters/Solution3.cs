namespace LeetCode.Problems._0316_Remove_Duplicate_Letters;

/// <summary>
/// https://leetcode.com/submissions/detail/1061018591/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string RemoveDuplicateLetters(string s)
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
