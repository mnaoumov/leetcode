namespace LeetCode.Problems._2451_Odd_String_Difference;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-90/submissions/detail/832701312/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string OddString(string[] words)
    {
        var diffList0 = new List<int>();
        var diffList1 = new List<int>();
        var doesWord0And1Differ = false;

        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];

            for (var j = 0; j < word.Length - 1; j++)
            {
                var diff = word[j + 1] - word[j];

                switch (i)
                {
                    case 0:
                        diffList0.Add(diff);
                        break;
                    case 1:
                        {
                            diffList1.Add(diff);

                            if (diffList0[j] != diff)
                            {
                                doesWord0And1Differ = true;
                            }

                            break;
                        }
                    default:
                        {
                            if (diffList0[j] != diff)
                            {
                                return doesWord0And1Differ
                                    ? words[0]
                                    : word;
                            }

                            if (doesWord0And1Differ && diffList1[j] != diff)
                            {
                                return words[1];
                            }

                            break;
                        }
                }
            }
        }

        return "";
    }
}
