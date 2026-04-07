using System.Text;

namespace LeetCode.Problems._2075_Decode_the_Slanted_Ciphertext;

/// <summary>
/// https://leetcode.com/problems/decode-the-slanted-ciphertext/submissions/1968161221/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        var l = encodedText.Length;
        var columns = l / rows;

        var sb = new StringBuilder();

        var rowIndex = 0;
        var columnIndex = 0;

        while (columnIndex < columns)
        {
            sb.Append(encodedText[rowIndex * columns + columnIndex]);
            rowIndex++;
            columnIndex++;

            if (rowIndex < rows)
            {
                continue;
            }

            rowIndex = 0;
            columnIndex -= rows - 1;
        }

        return sb.ToString().TrimEnd();
    }
}
