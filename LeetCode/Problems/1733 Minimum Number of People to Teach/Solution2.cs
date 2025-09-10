namespace LeetCode.Problems._1733_Minimum_Number_of_People_to_Teach;

/// <summary>
/// https://leetcode.com/problems/minimum-number-of-people-to-teach/submissions/1765569967/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        var m = languages.Length;
        var friendsMap = Enumerable.Range(1, m).Select(_ => new List<int>()).ToArray();

        foreach (var friendship in friendships)
        {
            var u = friendship[0];
            var v = friendship[1];
            friendsMap[u - 1].Add(v - 1);
            friendsMap[v - 1].Add(u - 1);
        }

        var ans = int.MaxValue;

        for (var languageToLearn = 1; languageToLearn <= n; languageToLearn++)
        {
            var usersLearnt = new HashSet<int>();

            for (var user = 0; user < m; user++)
            {
                if (languages[user].Contains(languageToLearn) || usersLearnt.Contains(user))
                {
                    continue;
                }

                foreach (var friend in friendsMap[user].Where(friend => !languages[user].Intersect(languages[friend]).Any()))
                {
                    usersLearnt.Add(user);
                    if (!languages[friend].Contains(languageToLearn))
                    {
                        usersLearnt.Add(friend);
                    }
                }
            }

            ans = Math.Min(ans, usersLearnt.Count);
        }

        return ans;
    }
}
