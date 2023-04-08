using JetBrains.Annotations;

namespace LeetCode._0299_Bulls_and_Cows;

[PublicAPI]
public interface ISolution
{
    public string GetHint(string secret, string guess);
}
