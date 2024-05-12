using JetBrains.Annotations;

namespace LeetCode.Problems._1472_Design_Browser_History;

/// <summary>
/// https://leetcode.com/submissions/detail/917631234/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IBrowserHistory Create(string homepage) => new BrowserHistory(homepage);

    private class BrowserHistory : IBrowserHistory
    {
        private Node _node;

        public BrowserHistory(string homepage)
        {
            _node = new Node(homepage);
        }

        public void Visit(string url)
        {
            if (_node.Next != null)
            {
                _node.Next.Previous = null;
                _node.Next = null;
            }

            _node.Next = new Node(url)
            {
                Previous = _node
            };

            _node = _node.Next;
        }

        public string Back(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                if (_node.Previous == null)
                {
                    break;
                }

                _node = _node.Previous;
            }

            return _node.Url;
        }

        public string Forward(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                if (_node.Next == null)
                {
                    break;
                }

                _node = _node.Next;
            }

            return _node.Url;
        }

        private record Node(string Url)
        {
            public Node? Next { get; set; }
            public Node? Previous { get; set; }
        }
    }
}
