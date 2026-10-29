namespace LeetCode.Problems._0158_Read_N_Characters_Given_read4_II___Call_Multiple_Times;

/// <summary>
/// https://leetcode.com/submissions/detail/864590421/
/// </summary>
[UsedImplicitly]
public class Solution1 : Reader4
{
    private readonly List<char> _leftovers = new();

    public override int Read(char[] buf, int n)
    {
        var readCount = 0;
        var index = 0;

        while (_leftovers.Count > 0)
        {
            if (readCount == n)
            {
                return n;
            }

            buf[index] = _leftovers[0];
            _leftovers.RemoveAt(0);
            index++;
            readCount++;
        }

        var buf4 = new char[4];

        while (readCount < n)
        {
            var readCount4 = Read4(buf4);

            if (readCount4 == 0)
            {
                return readCount;
            }

            for (var i = 0; i < readCount4; i++)
            {
                if (readCount < n)
                {
                    buf[index] = buf4[i];
                    index++;
                    readCount++;
                }
                else
                {
                    _leftovers.Add(buf4[i]);
                }
            }
        }

        return readCount;
    }
}
