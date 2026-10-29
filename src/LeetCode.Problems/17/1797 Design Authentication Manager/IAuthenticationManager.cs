namespace LeetCode.Problems._1797_Design_Authentication_Manager;

[PublicAPI]
public interface IAuthenticationManager
{
    void Generate(string tokenId, int currentTime);
    void Renew(string tokenId, int currentTime);
    int CountUnexpiredTokens(int currentTime);
}
