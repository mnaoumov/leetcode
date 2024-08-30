namespace LeetCode
{
    public class Node
    {
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public int val;
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public IList<Node> children;

        // ReSharper disable once MemberCanBePrivate.Global
        public Node() : this(0, new List<Node>())
        {
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public Node(int val) : this(val, new List<Node>())
        {
            this.val = val;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public Node(int val, IList<Node> children)
        {
            this.val = val;
            this.children = children;
        }

        public static Node? CreateOrNull(int?[] values)
        {
            var rootParent = new Node();
            var previousLevelNodes = new List<Node> { rootParent };
            var currentLevelNodes = new List<Node>();

            var parentIndex = 0;

            foreach (var value in values)
            {
                if (value != null)
                {
                    var node = new Node(value.Value);
                    previousLevelNodes[parentIndex].children.Add(node);
                    currentLevelNodes.Add(node);
                }
                else
                {
                    parentIndex++;

                    if (parentIndex != previousLevelNodes.Count)
                    {
                        continue;
                    }

                    parentIndex = 0;
                    previousLevelNodes = currentLevelNodes;
                    currentLevelNodes = new List<Node>();
                }
            }

            return rootParent.children.FirstOrDefault();
        }

        public override string ToString() => $"{{{val}}}";
    }
}
