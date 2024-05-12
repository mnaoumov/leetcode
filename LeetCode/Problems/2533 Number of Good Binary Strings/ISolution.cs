using JetBrains.Annotations;

namespace LeetCode.Problems._2533_Number_of_Good_Binary_Strings;

[PublicAPI]
public interface ISolution
{
    public int GoodBinaryStrings(int minLength, int maxLength, int oneGroup, int zeroGroup);
}
