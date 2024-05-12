using JetBrains.Annotations;

namespace LeetCode._1203_Sort_Items_by_Groups_Respecting_Dependencies;

[PublicAPI]
public interface ISolution
{
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems);
}
