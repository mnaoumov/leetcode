namespace LeetCode.Problems._1244_Design_A_Leaderboard;

/// <summary>
/// https://leetcode.com/problems/design-a-leaderboard/submissions/1871449569/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ILeaderboard Create() => new Leaderboard();

    private class Leaderboard : ILeaderboard
    {
        private readonly Dictionary<int, int> _playerScores = new();

        private readonly SortedSet<Key> _sortedScores = new(Comparer<Key>.Create((key1, key2) =>
            (key2.Score, key2.PlayerId).CompareTo((key1.Score, key1.PlayerId))));

        public void AddScore(int playerId, int score)
        {
            if (_playerScores.TryAdd(playerId, 0))
            {
                _sortedScores.Add(new Key(0, playerId));
            }

            var oldScore = _playerScores[playerId];
            var newScore = oldScore + score;
            _playerScores[playerId] = newScore;
            _sortedScores.Remove(new Key(oldScore, playerId));
            _sortedScores.Add(new Key(newScore, playerId));
        }

        // ReSharper disable once InconsistentNaming
        public int Top(int K) => _sortedScores.Take(K).Select(key => key.Score).Sum();

        public void Reset(int playerId)
        {
            var score = _playerScores[playerId];
            AddScore(playerId, -score);
        }

        private record Key(int Score, int PlayerId);
    }
}
