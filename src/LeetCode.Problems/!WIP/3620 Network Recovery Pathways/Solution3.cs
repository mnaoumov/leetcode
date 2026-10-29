namespace LeetCode.Problems._3620_Network_Recovery_Pathways;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int FindMaxPathScore(int[][] edges, bool[] online, long k)
    {
        var n = online.Length;
        var g = new List<(int, int)>[n];

        for (var i = 0; i < n; i++)
        {
            g[i] = new List<(int, int)>();
        }

        int l = int.MaxValue, r = 0;
        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1], w = edge[2];
            if (!online[u] || !online[v])
            {
                continue;
            }
            g[u].Add((v, w));
            l = Math.Min(l, w);
            r = Math.Max(r, w);
        }

        if (!Check(l))
        {
            return -1;
        }

        while (l <= r)
        {
            var mid = (l + r) >> 1;
            if (Check(mid))
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }
        return r;

        bool Check(int mid)
        {
            var dis = new long[n];
            Array.Fill(dis, long.MaxValue);
            var pq = new SortedSet<(long, int)>();

            dis[0] = 0;
            pq.Add((0, 0));

            while (pq.Count > 0)
            {
                var (d, u) = pq.Min;
                pq.Remove(pq.Min);

                if (d > k)
                {
                    return false;
                }

                if (u == n - 1)
                {
                    return true;
                }
                if (d > dis[u])
                {
                    continue;
                }

                foreach (var (v, w) in g[u])
                {
                    if (w < mid)
                    {
                        continue;
                    }

                    if (dis[v] <= dis[u] + w)
                    {
                        continue;
                    }

                    if (dis[v] != long.MaxValue)
                    {
                        pq.Remove((dis[v], v));
                    }
                    dis[v] = dis[u] + w;
                    pq.Add((dis[v], v));
                }
            }
            return false;
        }
    }
}