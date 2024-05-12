using JetBrains.Annotations;

namespace LeetCode._0119_Pascal_s_Triangle_II;

[PublicAPI]
public interface ISolution
{
    public IList<int> GetRow(int rowIndex);
}
