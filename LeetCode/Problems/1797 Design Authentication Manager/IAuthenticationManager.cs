using JetBrains.Annotations;

namespace LeetCode.Problems._1797_Design_Authentication_Manager;

[PublicAPI]
public interface IAuthenticationManager
{
    public void Generate(string tokenId, int currentTime);
    public void Renew(string tokenId, int currentTime);
    public int CountUnexpiredTokens(int currentTime);
}
