using JetBrains.Annotations;

namespace LeetCode._1291_Sequential_Digits;

[PublicAPI]
public interface ISolution
{
    public IList<int> SequentialDigits(int low, int high);
}
