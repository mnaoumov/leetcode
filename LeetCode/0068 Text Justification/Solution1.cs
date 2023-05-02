using System.Text;

using JetBrains.Annotations;

namespace LeetCode._0068_Text_Justification;

/// <summary>
/// https://leetcode.com/submissions/detail/819855226/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> FullJustify(string[] words, int maxWidth)
    {
        var result = new List<string>();

        var lineMinLength = -1;
        var lineWords = new List<string>();

        foreach (var word in words)
        {
            var lineMinLengthCandidate = lineMinLength + 1 + word.Length;
            if (lineMinLengthCandidate <= maxWidth)
            {
                lineWords.Add(word);
                lineMinLength = lineMinLengthCandidate;
            }
            else
            {
                if (lineWords.Count == 1)
                {
                    result.Add(lineWords[0].PadRight(maxWidth));
                }
                else
                {
                    var totalSpacesCount = maxWidth - lineMinLength + lineWords.Count - 1;
                    var evenlyDistributedSpacesCount = totalSpacesCount / (lineWords.Count - 1);
                    var leftOversSpaceCount = totalSpacesCount - evenlyDistributedSpacesCount * (lineWords.Count - 1);

                    var sb = new StringBuilder();

                    var i = 0;

                    foreach (var lineWord in lineWords)
                    {
                        int spacesCount;
                        if (i < leftOversSpaceCount)
                        {
                            spacesCount = evenlyDistributedSpacesCount + 1;
                        }
                        else if (i < lineWords.Count - 1)
                        {
                            spacesCount = evenlyDistributedSpacesCount;
                        }
                        else
                        {
                            spacesCount = 0;
                        }

                        sb.Append(lineWord);
                        sb.Append(' ', spacesCount);

                        i++;
                    }

                    result.Add(sb.ToString());
                }

                lineMinLength = word.Length;
                lineWords.Clear();
                lineWords.Add(word);
            }
        }

        result.Add(string.Join(" ", lineWords).PadRight(maxWidth));
        return result.ToArray();
    }
}
