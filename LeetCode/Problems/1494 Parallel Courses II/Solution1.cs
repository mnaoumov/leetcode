namespace LeetCode.Problems._1494_Parallel_Courses_II;

/// <summary>
/// https://leetcode.com/submissions/detail/974265741/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinNumberOfSemesters(int n, int[][] relations, int k)
    {
        var indegrees = new int[n];
        var nextCourses = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var relation in relations)
        {
            indegrees[relation[1] - 1]++;
            nextCourses[relation[0] - 1].Add(relation[1] - 1);
        }

        var dp = new DynamicProgramming<string, int>((indegreesStr, recursiveFunc) =>
        {
            indegrees = indegreesStr.Split(',').Select(int.Parse).ToArray();

            var zeroIndegreesCourses = Enumerable.Range(0, n).Where(i => indegrees[i] == 0).ToArray();

            if (zeroIndegreesCourses.Length == 0)
            {
                return 0;
            }

            var ans = int.MaxValue;

            var semesterCourses = new List<int>();
            Backtrack(0);

            return ans;

            void Backtrack(int index)
            {
                var semesterCoursesCount = semesterCourses.Count;

                if (semesterCoursesCount == k || index == zeroIndegreesCourses.Length)
                {
                    foreach (var course in semesterCourses.SelectMany(semesterCourse => nextCourses[semesterCourse].Append(semesterCourse)))
                    {
                        indegrees[course]--;
                    }

                    ans = Math.Min(ans, 1 + recursiveFunc(string.Join(',', indegrees)));

                    foreach (var course in semesterCourses.SelectMany(semesterCourse => nextCourses[semesterCourse].Append(semesterCourse)))
                    {
                        indegrees[course]++;
                    }

                    return;
                }

                if (semesterCoursesCount + zeroIndegreesCourses.Length - index <= k)
                {
                    semesterCourses.AddRange(zeroIndegreesCourses[index..]);
                    Backtrack(zeroIndegreesCourses.Length);
                    semesterCourses.RemoveRange(semesterCoursesCount, semesterCourses.Count - semesterCoursesCount);
                    return;
                }

                Backtrack(index + 1);

                semesterCourses.Add(zeroIndegreesCourses[index]);
                Backtrack(index + 1);
                semesterCourses.RemoveAt(semesterCoursesCount);
            }
        });

        return dp.GetOrCalculate(string.Join(',', indegrees));
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
