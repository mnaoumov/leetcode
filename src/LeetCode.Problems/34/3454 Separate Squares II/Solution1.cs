namespace LeetCode.Problems._3454_Separate_Squares_II;

/// <summary>
/// https://leetcode.com/problems/separate-squares-ii/submissions/1884343445/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double SeparateSquares(int[][] squares)
    {
        var xSet = new SortedSet<int>();
        foreach (var sq in squares)
        {
            var x = sq[0];
            var l = sq[2];
            xSet.Add(x - 1);
            xSet.Add(x);
            xSet.Add(x + l - 1);
            xSet.Add(x + l);
        }

        var xMap = new Dictionary<int, int>();
        var index = 0;

        foreach (var x in xSet)
        {
            xMap[x] = index++;
        }

        var events = new List<Event>();
        foreach (var sq in squares)
        {
            var x1 = sq[0];
            var y = sq[1];
            var l = sq[2];
            var x2 = x1 + l - 1;
            events.Add(new Event(xMap[x1], xMap[x2], y, EventType.Start));
            events.Add(new Event(xMap[x1], xMap[x2], y + l, EventType.End));
        }

        events.Sort((a, b) => a.Y.CompareTo(b.Y));
        var segmentTree = new SegmentTree(xSet);

        var prevY = events[0].Y;
        long totalArea = 0;

        foreach (var e in events)
        {
            totalArea += 1L * (e.Y - prevY) * segmentTree.CoveredLength();
            prevY = e.Y;
            segmentTree.Update(e.X1, e.X2, (int) e.Type);
        }

        var currentArea = 0L;
        prevY = events[0].Y;

        foreach (var e in events)
        {
            var nextArea = currentArea + 1L * (e.Y - prevY) * segmentTree.CoveredLength();
            if (nextArea >= (totalArea + 1) / 2)
            {
                var remaining = (totalArea / 2.0) - currentArea;
                return prevY + remaining / segmentTree.CoveredLength();
            }
            currentArea = nextArea;
            prevY = e.Y;
            segmentTree.Update(e.X1, e.X2, (int) e.Type);
        }

        throw new Exception("No valid line found.");
    }

    private enum EventType
    {
        End = -1,
        Start = 1
    }

    private record Event(int X1, int X2, int Y, EventType Type);

    private class Node
    {
        public int CoveredCount { get; set; }
        public int CoveredLength { get; set; }
        public bool IsLeftCovered { get; set; }
        public bool IsRightCovered { get; set; }
    }

    private class SegmentTree
    {
        private readonly List<int> _vals;
        private readonly Node[] _tree;
        private readonly int _size;

        public SegmentTree(SortedSet<int> xVals)
        {
            _vals = xVals.ToList();
            _size = _vals.Count;
            _tree = new Node[_size * 4];

            for (var i = 0; i < _tree.Length; i++)
            {
                _tree[i] = new Node();
            }
        }

        public void Update(int l, int r, int delta) => Update(l, r, delta, 1, 0, _size - 1);

        private void Update(int l, int r, int delta, int v, int vl, int vr)
        {
            if (vl > r || vr < l) return;

            if (l <= vl && vr <= r)
            {
                _tree[v].CoveredCount += delta;
            }
            else
            {
                var mid = (vl + vr) / 2;
                Update(l, r, delta, v * 2, vl, mid);
                Update(l, r, delta, v * 2 + 1, mid + 1, vr);
            }

            if (_tree[v].CoveredCount > 0)
            {
                _tree[v].CoveredLength = _vals[vr] - _vals[vl] + 1;
                _tree[v].IsLeftCovered = _tree[v].IsRightCovered = true;
            }
            else if (vl == vr)
            {
                _tree[v].CoveredLength = 0;
                _tree[v].IsLeftCovered = _tree[v].IsRightCovered = false;
            }
            else
            {
                _tree[v].CoveredLength = _tree[v * 2].CoveredLength + _tree[v * 2 + 1].CoveredLength;
                var mid = (vl + vr) / 2;
                if (_tree[v * 2].IsRightCovered && _tree[v * 2 + 1].IsLeftCovered)
                {
                    _tree[v].CoveredLength += _vals[mid + 1] - _vals[mid] - 1;
                }
                _tree[v].IsLeftCovered = _tree[v * 2].IsLeftCovered;
                _tree[v].IsRightCovered = _tree[v * 2 + 1].IsRightCovered;
            }
        }

        public int CoveredLength() => _tree[1].CoveredLength;
    }
}