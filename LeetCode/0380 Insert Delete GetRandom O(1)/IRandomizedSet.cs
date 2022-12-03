using JetBrains.Annotations;

namespace LeetCode._0380_Insert_Delete_GetRandom_O_1_;

public interface IRandomizedSet
{
    public bool Insert(int val);
    public bool Remove(int val);
    public int GetRandom();
}
