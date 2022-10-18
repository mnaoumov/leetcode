using JetBrains.Annotations;

namespace LeetCode._0658_Find_K_Closest_Elements;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x);
}