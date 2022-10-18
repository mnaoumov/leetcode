using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0990_Satisfiability_of_Equality_Equations;

/// <summary>
/// https://leetcode.com/submissions/detail/809093485/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool EquationsPossible(string[] equations)
    {
        var distinctVariables = new HashSet<char>();
        var equivalenceChainMap = new Dictionary<char, char>();

        foreach (var equation in equations)
        {
            var variable1 = equation[0];
            var isEqual = equation[1] == '=';
            var variable2 = equation[3];

            char GetEquivalenceChainRoot(char variable)
            {
                var next = variable;

                do
                {
                    variable = next;
                    if (equivalenceChainMap.TryGetValue(next, out var newNext))
                    {
                        next = newNext;
                    }
                } while (next != variable);

                return next;
            }

            var root1 = GetEquivalenceChainRoot(variable1);
            var root2 = GetEquivalenceChainRoot(variable2);

            if (isEqual)
            {
                if (root1 == root2)
                {
                    continue;
                }

                if (distinctVariables.Contains(root1) && distinctVariables.Contains(root2))
                {
                    return false;
                }

                equivalenceChainMap[root2] = root1;
            }
            else
            {
                if (root1 == root2)
                {
                    return false;
                }

                distinctVariables.Add(root1);
                distinctVariables.Add(root2);
            }
        }

        return true;
    }
}