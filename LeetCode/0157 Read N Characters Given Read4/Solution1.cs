using JetBrains.Annotations;

namespace LeetCode._0157_Read_N_Characters_Given_Read4;

/// <summary>
/// https://leetcode.com/problems/read-n-characters-given-read4/submissions/848313548/
/// </summary>
[UsedImplicitly]
public class Solution1 : Reader4
{
    public override int Read(char[] buf, int n)
    {
        var buf4 = new char[4];

        var index = 0;

        while (true)
        {
            var bytesRead = Read4(buf4);

            if (bytesRead == 0)
            {
                break;
            }

            for (var i = 0; i < bytesRead; i++)
            {
                buf[index] = buf4[i];
                index++;

                if (index == n)
                {
                    break;
                }
            }

            if (index == n)
            {
                break;
            }
        }

        return index;
    }
}