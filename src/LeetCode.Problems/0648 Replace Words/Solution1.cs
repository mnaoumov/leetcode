namespace LeetCode.Problems._0648_Replace_Words;

/// <summary>
/// https://leetcode.com/submissions/detail/1280042864/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        dictionary = dictionary.OrderBy(root => root.Length).ToArray();

        var words = sentence.Split(' ');
        return string.Join(" ",words.Select(ToRoot));

        string ToRoot(string word)
        {
            foreach (var root in dictionary)
            {
                if (word.StartsWith(root))
                {
                    return root;
                }
            }

            return word;
        }
    }
}
