using JetBrains.Annotations;

namespace LeetCode._0953_Verifying_an_Alien_Dictionary;

[PublicAPI]
public interface ISolution
{
    public bool IsAlienSorted(string[] words, string order);
}
