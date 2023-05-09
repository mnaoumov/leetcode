using Newtonsoft.Json;

namespace LeetCode._0430_Flatten_a_Multilevel_Doubly_Linked_List
{
    public class Node : IEquatable<Node>
    {
        // ReSharper disable once InconsistentNaming
        public int val;

        // ReSharper disable once InconsistentNaming
        public Node? prev;

        // ReSharper disable once InconsistentNaming
        public Node? next;

        // ReSharper disable once InconsistentNaming
        public Node? child;

        public static Node? CreateOrNull(IEnumerable<int?> values)
        {
            var root = new Node();
            var node = root;
            Node? currentLevelStartNode = null;
            Node? parentNode = null;

            foreach (var value in values)
            {
                if (value != null)
                {
                    node.next = new Node { val = (int) value };

                    if (node.val != 0)
                    {
                        node.next.prev = node;
                    }

                    node = node.next;

                    if (currentLevelStartNode != null)
                    {
                        continue;
                    }

                    if (parentNode != null)
                    {
                        parentNode.child = node;
                    }

                    currentLevelStartNode = node;
                }
                else if (currentLevelStartNode != null)
                {
                    parentNode = currentLevelStartNode;
                    currentLevelStartNode = null;
                    node = new Node();
                }
                else
                {
                    parentNode = parentNode!.next;
                }
            }

            return root.next;
        }

        public bool Equals(Node? other) => other != null && ToString() == other.ToString();

        public override bool Equals(object? obj) => obj?.GetType() == GetType() && Equals((Node) obj);

        // ReSharper disable NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => HashCode.Combine(val, prev?.val, next?.val, child?.val);
        // ReSharper restore NonReadonlyMemberInGetHashCode

        public override string ToString() => JsonConvert.SerializeObject(GetValues(this));

        private static List<int?> GetValues(Node node)
        {
            var values = new List<int?>();

            var node2 = node;
            var nullsCount = 0;
            Node? child = null;

            while (node2 != null)
            {
                values.Add(node2.val);
                nullsCount++;

                if (node2.child != null)
                {
                    child = node2.child;
                }

                node2 = node2.next;
            }

            if (child == null)
            {
                return values;
            }

            values.AddRange(Enumerable.Repeat<int?>(null, nullsCount));
            values.AddRange(GetValues(child));
            return values;
        }
    }
}
