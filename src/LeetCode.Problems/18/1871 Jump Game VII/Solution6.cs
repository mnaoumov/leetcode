namespace LeetCode.Problems._1871_Jump_Game_VII;

/// <summary>
/// https://leetcode.com/problems/jump-game-vii/submissions/2013038607/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        var n = s.Length;

        var zeroIndexIntervals = new List<Interval> { new Interval(0, 0) };

        for (var i = 1; i < n; i++)
        {
            if (s[i] != '0')
            {
                continue;
            }

            if (zeroIndexIntervals[^1].To == i - 1)
            {
                zeroIndexIntervals[^1] = zeroIndexIntervals[^1] with { To = i };
            }
            else
            {
                zeroIndexIntervals.Add(new Interval(i, i));
            }
        }

        if (zeroIndexIntervals[^1].To != n - 1)
        {
            return false;
        }

        var queue = new Queue<Interval>();
        queue.Enqueue(new Interval(n - 1, n - 1));

        while (queue.Count > 0)
        {
            var (a, b) = queue.Dequeue();

            if (a == 0)
            {
                return true;
            }

            var c = a - maxJump;
            var d = b - minJump;

            if (d < 0)
            {
                continue;
            }

            if (c <= 0)
            {
                c = 0;
            }

            var cIndex = zeroIndexIntervals.BinarySearch(new Interval(c, c), Interval.FromComparer);

            if (cIndex < 0)
            {
                cIndex = ~cIndex - 1;

                if (0 <= cIndex && cIndex < zeroIndexIntervals.Count)
                {
                    var interval = zeroIndexIntervals[cIndex];

                    if (interval.To >= c)
                    {
                        queue.Enqueue(new Interval(c, Math.Min(d, interval.To)));
                    }
                }

                cIndex++;
            }

            var dIndex = zeroIndexIntervals.BinarySearch(new Interval(d, d), Interval.ToComparer);

            if (dIndex < 0)
            {
                dIndex = ~dIndex;

                if (cIndex <= dIndex && dIndex < zeroIndexIntervals.Count)
                {
                    var interval = zeroIndexIntervals[dIndex];

                    if (interval.From <= d)
                    {
                        queue.Enqueue(interval with { To = d });
                    }
                }

                dIndex--;
            }

            for (var index = cIndex; index <= dIndex; index++)
            {
                queue.Enqueue(zeroIndexIntervals[index]);
            }
        }

        return false;
    }

    private sealed record Interval(int From, int To)
    {
        public static readonly IComparer<Interval>
            FromComparer = Comparer<Interval>.Create((x, y) => x.From.CompareTo(y.From));
        public static readonly IComparer<Interval>
            ToComparer = Comparer<Interval>.Create((x, y) => x.To.CompareTo(y.To));
    }
}
