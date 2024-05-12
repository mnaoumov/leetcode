using Newtonsoft.Json;

namespace LeetCode.Problems._1522_Diameter_of_N_Ary_Tree
{
    public class Node
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once InconsistentNaming
        public readonly int val;

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once InconsistentNaming
        public IList<Node>? children;

        private Node(int val) => this.val = val;

        public static Node? CreateOrNull(int?[] values)
        {
            if (values.Length == 0)
            {
                return null;
            }

            var fakeRoot = new Node(0);
            var parent = fakeRoot;
            var queue = new Queue<Node>();

            foreach (var value in values)
            {
                if (value == null)
                {
                    parent = queue.Dequeue();
                    continue;
                }

                parent.children ??= new List<Node>();

                var node = new Node(value.Value);
                parent.children.Add(node);
                queue.Enqueue(node);
            }

            return fakeRoot.children![0];
        }

        public override string ToString()
        {
            var queue = new Queue<Node?>();
            queue.Enqueue(this);
            queue.Enqueue(null);
            var values = new List<int?>();

            while (queue.Count > 0)
            {
                var count = queue.Count;

                for (var i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();

                    values.Add(node?.val);

                    if (node == null)
                    {
                        continue;
                    }

                    foreach (var child in node.children ?? new List<Node>())
                    {
                        queue.Enqueue(child);
                    }

                    queue.Enqueue(null);
                }
            }

            while (values[^1] == null)
            {
                values.RemoveAt(values.Count - 1);
            }

            return JsonConvert.SerializeObject(values);
        }
    }
}
