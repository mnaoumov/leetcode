using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0726_Number_of_Atoms;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public string CountOfAtoms(string formula)
    {
        var root = new Node(null);
        var node = root.StartGroup();

        foreach (var symbol in formula)
        {
            if (char.IsLetter(symbol))
            {
                if (char.IsUpper(symbol))
                {
                    node = node.CreateSibling();
                }

                node.Element += symbol;
            }
            else if (char.IsDigit(symbol))
            {
                var digit = symbol - '0';
                node.Count = 10 * node.Count + digit;
            }
            else
            {
                node = symbol switch
                {
                    '(' => node.Parent!.StartGroup(),
                    ')' => node.EndGroup(),
                    _ => node
                };
            }
        }

        return string.Concat(root.GetCounts().OrderBy(x => x.Key)
            .Select(x => x.Value == 1 ? x.Key : $"{x.Key}{x.Value}")
        );
    }

    private class Node
    {
        public Node? Parent { get; }
        private readonly List<Node> _children = new();

        public Node(Node? parent)
        {
            if (parent == null)
            {
                return;
            }

            Parent = parent;
            Parent._children.Add(this);
        }

        public Node CreateSibling() => new(Parent);

        public string? Element { get; set; }
        public int Count { get; set; }
        private int RealCount => Count > 0 ? Count : 1;

        public Node StartGroup()
        {
            return new Node(this);
        }

        public Node EndGroup()
        {
            return Parent!;
        }

        public IDictionary<string, int> GetCounts()
        {
            var ans = new Dictionary<string, int>();
            UpdateCounts(ans);
            return ans;
        }

        private void UpdateCounts(IDictionary<string, int> counts, int multiplier = 1)
        {
            foreach (var child in _children)
            {
                child.UpdateCounts(counts, RealCount * multiplier);
            }

            if (Element == null)
            {
                return;
            }

            counts.TryAdd(Element, 0);
            counts[Element] += RealCount * multiplier;
        }
    }
}
