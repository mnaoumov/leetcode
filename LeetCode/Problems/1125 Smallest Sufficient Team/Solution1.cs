namespace LeetCode.Problems._1125_Smallest_Sufficient_Team;

/// <summary>
/// https://leetcode.com/submissions/detail/996247112/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable once InconsistentNaming
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
    {
        var skillIdMap = new Dictionary<string, int>();
        var n = req_skills.Length;
        var m = people.Count;

        for (var i = 0; i < n; i++)
        {
            skillIdMap[req_skills[i]] = i;
        }

        var peopleBySkillId = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var skillIdsByPerson= Enumerable.Range(0, m).Select(_ => new List<int>()).ToArray();

        for (var person = 0; person < m; person++)
        {
            foreach (var skill in people[person])
            {
                var skillId = skillIdMap[skill];
                peopleBySkillId[skillId].Add(person);
                skillIdsByPerson[person].Add(skillId);
            }
        }

        var allSkillsMask = (1 << n) - 1;

        var dp = new DynamicProgramming<int, List<int>>((skillsMask, recursiveFunc) =>
        {
            if (skillsMask == allSkillsMask)
            {
                return new List<int>();
            }

            var set = new List<int>();

            for (var skillId = 0; skillId < n; skillId++)
            {
                if ((skillsMask & 1 << skillId) != 0)
                {
                    continue;
                }

                foreach (var person in peopleBySkillId[skillId])
                {
                    var nextSkillsMask = skillIdsByPerson[person].Aggregate(skillsMask, (current, nextSkillId) => current | 1 << nextSkillId);

                    var nextSet = recursiveFunc(nextSkillsMask);

                    if (set.Count != 0 && set.Count <= 1 + nextSet.Count)
                    {
                        continue;
                    }

                    set = nextSet.ToList();
                    set.Add(person);
                }

                break;
            }

            return set;
        });

        return dp.GetOrCalculate(0).ToArray();
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
