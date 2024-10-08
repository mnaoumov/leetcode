
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0056_Merge_Intervals;

/// <summary>
/// https://leetcode.com/submissions/detail/819434184/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[][] Merge(int[][] intervals)
    {
        var intervalObjs = new List<Interval>();

        foreach (var intervalArray in intervals)
        {
            var intervalObj = Interval.FromArray(intervalArray);
            const int notInsertedIndex = -1;
            var insertedIndex = notInsertedIndex;

            for (var i = 0; i < intervalObjs.Count; i++)
            {
                var otherIntervalObj = intervalObjs[i];
                if (intervalObj.IntersectsWith(otherIntervalObj))
                {
                    intervalObj = intervalObj.UnionWith(otherIntervalObj);

                    if (insertedIndex == notInsertedIndex)
                    {
                        insertedIndex = i;
                    }
                    else
                    {
                        intervalObjs.RemoveAt(i);
                        i--;
                    }

                    intervalObjs[insertedIndex] = intervalObj;
                }
            }

            if (insertedIndex == notInsertedIndex)
            {
                intervalObjs.Add(intervalObj);
            }
        }

        return intervalObjs.Select(i => i.ToArray()).ToArray();
    }

    record Interval(int Start, int End)
    {
        public static Interval FromArray(int[] array) => new(array[0], array[1]);

        public bool IntersectsWith(Interval otherInterval) => Math.Max(Start, otherInterval.Start) <= Math.Min(End, otherInterval.End);

        public Interval UnionWith(Interval otherInterval) => new(Math.Min(Start, otherInterval.Start), Math.Max(End, otherInterval.End));

        public int[] ToArray() => new[] { Start, End };
    }
}
