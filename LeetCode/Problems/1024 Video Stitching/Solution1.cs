using JetBrains.Annotations;

namespace LeetCode.Problems._1024_Video_Stitching;

/// <summary>
/// https://leetcode.com/submissions/detail/914153760/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int VideoStitching(int[][] clips, int time)
    {
        var sortedClips = clips.Select(x => (start: x[0], end: x[1])).OrderBy(x => x.start).ToArray();

        var start = 0;
        var end = 0;

        var i = 0;

        var result = 0;

        while (start < time)
        {
            while (i < sortedClips.Length && sortedClips[i].start <= start)
            {
                end = Math.Max(end, sortedClips[i].end);
                i++;
            }

            if (start == end)
            {
                return -1;
            }

            start = end;
            result++;
        }

        return result;
    }
}
