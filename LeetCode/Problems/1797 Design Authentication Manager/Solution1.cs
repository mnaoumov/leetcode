using JetBrains.Annotations;

namespace LeetCode.Problems._1797_Design_Authentication_Manager;

/// <summary>
/// https://leetcode.com/submissions/detail/966244768/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IAuthenticationManager Create(int timeToLive) => new AuthenticationManager(timeToLive);

    private class AuthenticationManager : IAuthenticationManager
    {
        private readonly int _timeToLive;
        private readonly Dictionary<string, int> _tokens = new();

        public AuthenticationManager(int timeToLive) => _timeToLive = timeToLive;

        public void Generate(string tokenId, int currentTime) => _tokens[tokenId] = currentTime + _timeToLive;

        public void Renew(string tokenId, int currentTime)
        {
            if (ValidateExpireTime(tokenId, currentTime))
            {
                _tokens[tokenId] = currentTime + _timeToLive;
            }
        }
    
        public int CountUnexpiredTokens(int currentTime)
        {
            foreach (var tokenId in _tokens.Keys.ToArray())
            {
                ValidateExpireTime(tokenId, currentTime);
            }

            return _tokens.Count;
        }

        private bool ValidateExpireTime(string tokenId, int currentTime)
        {
            if (!_tokens.TryGetValue(tokenId, out var expireTime))
            {
                return false;
            }

            if (expireTime > currentTime)
            {
                return true;
            }

            _tokens.Remove(tokenId);
            return false;
        }
    }
}
