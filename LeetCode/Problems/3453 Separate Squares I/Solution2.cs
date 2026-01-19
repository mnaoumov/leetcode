namespace LeetCode.Problems._3453_Separate_Squares_I;

/// <summary>
/// https://leetcode.com/problems/separate-squares-i/submissions/1883395318/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public double SeparateSquares(int[][] squares)
    {
        var squareObjs = squares.Select(arr => new Square(arr[1], arr[2])).OrderBy(s => s.Bottom).ToArray();
        var totalArea = squareObjs.Sum(s => s.Area);

        var low = (double) squareObjs.Min(s => s.Bottom);
        var high = (double) squareObjs.Max(s => s.Top);
        const double eps = 1e-5;

        while (high - low > eps)
        {
            var mid = (low + high) / 2;

            var area = squareObjs.TakeWhile(square => square.Bottom <= mid).Sum(square => (Math.Min(square.Top, mid) - square.Bottom) * square.SideLength);
            if (area < totalArea / 2)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }

    private record Square(int Bottom, int SideLength)
    {
        public double Area => 1d * SideLength * SideLength;
        public int Top => Bottom + SideLength;
    }
}
