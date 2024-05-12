using JetBrains.Annotations;

namespace LeetCode._0464_Can_I_Win;

[PublicAPI]
public interface ISolution
{
    public bool CanIWin(int maxChoosableInteger, int desiredTotal);
}
