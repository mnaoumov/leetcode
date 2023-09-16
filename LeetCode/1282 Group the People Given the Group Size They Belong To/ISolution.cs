using JetBrains.Annotations;

namespace LeetCode._1282_Group_the_People_Given_the_Group_Size_They_Belong_To;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> GroupThePeople(int[] groupSizes);
}
