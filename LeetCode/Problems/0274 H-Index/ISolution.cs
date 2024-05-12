using JetBrains.Annotations;

namespace LeetCode._0274_H_Index;

[PublicAPI]
public interface ISolution
{
    public int HIndex(int[] citations);
}
