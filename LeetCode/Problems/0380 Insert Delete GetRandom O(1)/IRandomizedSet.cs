using JetBrains.Annotations;

namespace LeetCode.Problems._0380_Insert_Delete_GetRandom_O_1_;

[PublicAPI]
public interface IRandomizedSet
{
    public bool Insert(int val);
    public bool Remove(int val);
    public int GetRandom();
}
