using JetBrains.Annotations;

namespace LeetCode.Problems._3161_Block_Placement_Queries;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-131/submissions/detail/1267629605/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<bool> GetResults(int[][] queries)
    {
        var ans = new List<bool>();
        var obstacles = new List<int> { 0, int.MaxValue };
        var maxSizes = new List<int> { 0, int.MaxValue };

        foreach (var query in queries)
        {
            var queryType = query[0];

            switch (queryType)
            {
                case 1:
                    {
                        var x = query[1];
                        PutObstacle(x);
                        break;
                    }
                case 2:
                    {
                        var x = query[1];
                        var sz = query[2];
                        ans.Add(CanPlace(x, sz));
                        break;
                    }
            }
        }

        return ans;

        void PutObstacle(int x)
        {
            var index = InsertInOrderedList(obstacles, x);
            var oldSize = obstacles[index + 1] - obstacles[index - 1];
            var size1 = obstacles[index] - obstacles[index - 1];
            var size2 = obstacles[index + 1] - obstacles[index];
            maxSizes[index] = Math.Max(maxSizes[index - 1], size1);
            maxSizes.Insert(index + 1, Math.Max(maxSizes[index], size2));

            if (oldSize <= maxSizes[index - 1])
            {
                return;
            }

            for (var i = index + 2; i < maxSizes.Count; i++)
            {
                if (maxSizes[i] > oldSize)
                {
                    break;
                }

                var size = obstacles[i] - obstacles[i - 1];

                if (size == oldSize)
                {
                    break;
                }

                maxSizes[i] = Math.Max(maxSizes[i - 1], size);
            }
        }

        bool CanPlace(int x, int sz)
        {
            var index = obstacles.BinarySearch(x);

            if (index >= 0)
            {
                return maxSizes[index] >= sz;
            }

            var previousObstacle = obstacles[~index - 1];
            return x - previousObstacle >= sz || CanPlace(previousObstacle, sz);
        }
    }

    private static int InsertInOrderedList<T>(List<T> list, T item)
    {
        var index = list.BinarySearch(item);

        if (index < 0)
        {
            index = ~index;
        }

        list.Insert(index, item);

        return index;
    }
}
