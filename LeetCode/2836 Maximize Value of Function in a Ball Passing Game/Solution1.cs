using JetBrains.Annotations;

namespace LeetCode._2836_Maximize_Value_of_Function_in_a_Ball_Passing_Game;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long GetMaxFunctionValue(IList<int> receiver, long k)
    {
        var n = receiver.Count;
        var pathsBeforeCycle = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var cycles = new List<int>?[n];

        for (var i = 0; i < n; i++)
        {
            var path = new List<int>();
            var valueToIndexMap = new Dictionary<int, int>();
            var value = i;

            while (!valueToIndexMap.ContainsKey(value))
            {
                path.Add(value);
                valueToIndexMap[value] = path.Count;
                value = receiver[value];
            }

            var previousIndex = valueToIndexMap[value];

            var cycle = path.Skip(previousIndex).ToList();
            var pathBeforeCycle = path.Take(previousIndex).ToList();

            foreach (var value2 in path)
            {
                cycles[value2] = cycle;
            }




            foreach (var value2 in path)
            {
            }



            for (var j = 0; j < previousIndex; j++)
            {
                pathsBeforeCycle[path[j]] = path.Skip(j).Take(previousIndex - 1 - j).ToList();
                cycles[path[j]] = cycle;
            }



        }

        throw new NotImplementedException();
    }
}
