using JetBrains.Annotations;

namespace LeetCode.Problems._1797_Design_Authentication_Manager;

[PublicAPI]
public interface ISolution
{
    public IAuthenticationManager Create(int timeToLive);
}
