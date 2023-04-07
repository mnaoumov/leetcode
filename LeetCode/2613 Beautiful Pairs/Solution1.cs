using JetBrains.Annotations;

namespace LeetCode._2613_Beautiful_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/929767003/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] BeautifulPair(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;

        var sortedX = new SortedSet<int>();
        var xToSortedYMap = new Dictionary<int, SortedSet<int>>();
        var xyIndexMap = new Dictionary<(int x, int y), int>();
        var result = (distance: Math.Abs(nums1[0] - nums1[1]) + Math.Abs(nums2[0] - nums2[1]), i: 0, j: 1);
        Save(0);
        Save(1);

        for (var j = 2; j < n; j++)
        {
            var x = nums1[j];
            var y = nums2[j];

            var xCandidates = sortedX.GetViewBetween(x - result.distance, x + result.distance);
  
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var xCandidate in xCandidates)
            {
                var xDistance = Math.Abs(x - xCandidate);

                if (xDistance > result.distance)
                {
                    continue;
                }

                var yDistanceCandidate = result.distance - xDistance;

                var yCandidates = xToSortedYMap[xCandidate]
                    .GetViewBetween(y - yDistanceCandidate, y + yDistanceCandidate);

                // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                foreach (var yCandidate in yCandidates)
                {
                    var distance = xDistance + Math.Abs(y - yCandidate);

                    var resultCandidate = (distance, xyIndexMap[(xCandidate, yCandidate)], j);

                    if (resultCandidate.CompareTo(result) < 0)
                    {
                        result = resultCandidate;
                    }
                }
            }

            Save(j);
        }

        return new[] { result.i, result.j };

        void Save(int index)
        {
            var x = nums1[index];
            var y = nums2[index];

            sortedX.Add(x);

            if (!xToSortedYMap.ContainsKey(x))
            {
                xToSortedYMap[x] = new SortedSet<int>();
            }

            xToSortedYMap[x].Add(y);
            xyIndexMap[(x, y)] = Math.Min(xyIndexMap.GetValueOrDefault((x, y), int.MaxValue), index);
        }
    }
}
