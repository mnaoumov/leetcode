namespace LeetCode.Problems._0990_Satisfiability_of_Equality_Equations;

/// <summary>
/// https://leetcode.com/submissions/detail/829083516/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool EquationsPossible(string[] equations)
    {
        var equalityChainMap = new Dictionary<char, char>();
        var nonEqualVariablesMap = new Dictionary<char, HashSet<char>>();

        foreach (var equation in equations)
        {
            var variable1 = equation[0];
            var isEqual = equation[1] == '=';
            var variable2 = equation[3];

            var root1 = GetEqualityChainRoot(variable1);
            var root2 = GetEqualityChainRoot(variable2);

            var nonEqualVariables1 = GetNonEqualVariables(root1);
            var nonEqualVariables2 = GetNonEqualVariables(root2);

            if (isEqual)
            {
                if (root1 == root2)
                {
                    continue;
                }

                if (nonEqualVariables1.Select(GetEqualityChainRoot).Any(root => root == root2))
                {
                    return false;
                }

                equalityChainMap[root2] = root1;
                nonEqualVariables1.UnionWith(nonEqualVariables2);
                nonEqualVariablesMap[root2] = new HashSet<char>();

            }
            else
            {
                if (root1 == root2)
                {
                    return false;
                }

                nonEqualVariables1.Add(root2);
                nonEqualVariables2.Add(root1);
            }

            continue;

            char GetEqualityChainRoot(char variable)
            {
                char current;
                var next = variable;

                var variablesToUpdate = new List<char>();

                do
                {
                    current = next;
                    variablesToUpdate.Add(current);
                    if (equalityChainMap.TryGetValue(next, out var newNext))
                    {
                        next = newNext;
                    }
                } while (next != current);

                foreach (var variableToUpdate in variablesToUpdate)
                {
                    equalityChainMap[variableToUpdate] = next;
                }

                return next;
            }
        }

        return true;

        HashSet<char> GetNonEqualVariables(char variable)
        {
            if (!nonEqualVariablesMap.TryGetValue(variable, out var result))
            {
                result = nonEqualVariablesMap[variable] = new HashSet<char>();
            }

            return result;
        }
    }
}
