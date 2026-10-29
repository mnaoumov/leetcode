namespace LeetCode.Problems._0380_Insert_Delete_GetRandom_O_1_;

[PublicAPI]
public interface IRandomizedSet
{
    bool Insert(int val);
    bool Remove(int val);
    int GetRandom();
}
