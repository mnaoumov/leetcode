using JetBrains.Annotations;

namespace LeetCode._2336_Smallest_Number_in_Infinite_Set;

[PublicAPI]
public interface ISmallestInfiniteSet
{
    public int PopSmallest();
    public void AddBack(int num);
}
