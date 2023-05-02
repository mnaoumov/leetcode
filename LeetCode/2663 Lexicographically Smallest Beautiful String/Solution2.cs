using System.Text;
using JetBrains.Annotations;

namespace LeetCode._2663_Lexicographically_Smallest_Beautiful_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-343/submissions/detail/941904474/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public string SmallestBeautifulString(string s, int k)
    {
        var sb = new StringBuilder(s);
        var maxLetter = (char) ('a' + k - 1);
        var n = s.Length;

        while (true)
        {
            var canIncrease = false;

            for (var i = n - 1; i >= 0; i--)
            {
                if (sb[i] == maxLetter)
                {
                    continue;
                }

                IncrementWord(i);

                canIncrease = true;
                break;
            }

            if (!canIncrease)
            {
                return "";
            }

            for (var i = 0; i < n - 1; i++)
            {
                int incrementIndex;

                if (i + 2 < n && sb[i] == sb[i + 2])
                {
                    incrementIndex = i + 2;
                }
                else if (sb[i] == sb[i + 1])
                {
                    incrementIndex = i + 1;
                }
                else
                {
                    continue;
                }

                if (sb[i] != maxLetter)
                {
                    IncrementWord(incrementIndex);
                }
                else
                {
                    canIncrease = false;

                    for (var j = i - 1; j >= 0; j--)
                    {
                        if (sb[j] == maxLetter)
                        {
                            continue;
                        }

                        IncrementWord(j);
                        canIncrease = true;
                        break;
                    }

                    if (!canIncrease)
                    {
                        return "";
                    }
                }
            }

            return sb.ToString();
        }

        void IncrementWord(int i)
        {
            sb[i] = (char) (sb[i] + 1);

            for (var j = i + 1; j < n; j++)
            {
                sb[j] = 'a';
            }
        }
    }
}
