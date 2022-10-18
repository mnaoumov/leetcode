using JetBrains.Annotations;

namespace LeetCode._1155_Number_of_Dice_Rolls_With_Target_Sum;

[PublicAPI]
public interface ISolution
{
    public int NumRollsToTarget(int n, int k, int target);
}