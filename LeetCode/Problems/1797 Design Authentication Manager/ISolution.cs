namespace LeetCode.Problems._1797_Design_Authentication_Manager;

[PublicAPI]
public interface ISolution
{
    IAuthenticationManager Create(int timeToLive);
}
