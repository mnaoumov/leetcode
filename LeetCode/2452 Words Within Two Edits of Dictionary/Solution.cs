using JetBrains.Annotations;

namespace LeetCode._2452_Words_Within_Two_Edits_of_Dictionary;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-90/submissions/detail/832711438/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        var result = new List<string>();

        foreach (var queryWord in queries)
        {
            foreach (var dictionaryWord in dictionary)
            {
                var differentLetterCount = 0;

                for (var i = 0; i < queryWord.Length; i++)
                {
                    if (queryWord[i] == dictionaryWord[i])
                    {
                        continue;
                    }

                    differentLetterCount++;

                    if (differentLetterCount > 2)
                    {
                        break;
                    }
                }

                if (differentLetterCount > 2)
                {
                    continue;
                }

                result.Add(queryWord);
                break;
            }
        }

        return result;
    }
}
