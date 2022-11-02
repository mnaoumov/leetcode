using JetBrains.Annotations;

namespace LeetCode._0118_Pascal_s_Triangle;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> Generate(int numRows);
}
