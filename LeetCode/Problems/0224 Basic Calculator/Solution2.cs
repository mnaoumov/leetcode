using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0224_Basic_Calculator;

/// <summary>
/// https://leetcode.com/problems/basic-calculator/submissions/847146664/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int Calculate(string s)
    {
        var rootNode = Node.Begin();

        var node = rootNode;

        foreach (var symbol in s)
        {
            switch (symbol)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    node = node.ProcessDigit(symbol - '0');
                    break;
                case '+':
                    node = node.ProcessPlus();
                    break;
                case '-':
                    node = node.ProcessMinus();
                    break;
                case '(':
                    node = node.ProcessOpenBracket();
                    break;
                case ')':
                    node = node.ProcessClosedBracket();
                    break;
                case ' ':
                    node = node.ProcessSpace();
                    break;
            }
        }

        return rootNode.Calculate();
    }

    private abstract class Node
    {
        private Node? Parent { get; set; }

        private Node(Node? parent)
        {
            Parent = parent;
        }

        public static Node Begin() => new GroupNode(null, true);

        public abstract int Calculate();

        public virtual Node ProcessDigit(int digit)
        {
            throw new NotImplementedException();
        }

        public virtual Node ProcessPlus() => Parent!.ProcessPlus();

        public virtual Node ProcessMinus() => Parent!.ProcessMinus();

        public virtual Node ProcessOpenBracket()
        {
            throw new NotImplementedException();
        }

        public virtual Node ProcessClosedBracket()
        {
            var parent = Parent!;

            while (parent is not GroupNode { IsOpen: true })
            {
                parent = parent!.Parent;
            }

            var groupNode = (GroupNode) parent;
            groupNode.IsOpen = false;
            return groupNode;
        }

        public Node ProcessSpace()
        {
            return this;
        }

        private class GroupNode : Node
        {
            public bool IsOpen { get; set; }

            public GroupNode(Node? parent, bool isOpen) : base(parent)
            {
                IsOpen = isOpen;
            }

            private Node? ChildNode { get; set; }

            public override int Calculate() => ChildNode!.Calculate();

            public override Node ProcessDigit(int digit)
            {
                ChildNode = new NumberNode(this, digit);
                return ChildNode;
            }

            public override Node ProcessPlus()
            {
                if (!IsOpen)
                {
                    return Parent!.ProcessPlus();
                }

                var plusGroupNode = new GroupNode(this, true);
                var plusNode = new PlusNode(this, ChildNode!);
                plusGroupNode.ChildNode = plusNode;
                ChildNode = plusGroupNode;
                return plusNode.RightSummand;
            }

            public override Node ProcessMinus()
            {
                if (!IsOpen)
                {
                    return Parent!.ProcessMinus();
                }


                if (ChildNode != null)
                {
                    var minusGroupNode = new GroupNode(this, true);
                    var binaryMinusNode = new BinaryMinusNode(this, ChildNode);
                    minusGroupNode.ChildNode = binaryMinusNode;
                    ChildNode = minusGroupNode;
                    return binaryMinusNode.Subtrahend;
                }

                var unaryMinusNode = new UnaryMinusNode(this);
                ChildNode = unaryMinusNode;
                return unaryMinusNode.ChildNode;
            }

            public override Node ProcessOpenBracket()
            {
                ChildNode = new GroupNode(this, true);
                return ChildNode;
            }
        }

        private class NumberNode : Node
        {
            private int Number { get; set; }

            public NumberNode(Node parent, int digit) : base(parent)
            {
                Number = digit;
            }

            public override int Calculate() => Number;

            public override Node ProcessDigit(int digit)
            {
                Number = 10 * Number + digit;
                return this;
            }
        }

        private class PlusNode : Node
        {
            private Node LeftSummand { get; }
            public Node RightSummand { get; }

            public PlusNode(Node parent, Node leftSummand) : base(parent)
            {
                LeftSummand = leftSummand;
                LeftSummand.Parent = this;
                RightSummand = new GroupNode(this, false);
            }

            public override int Calculate() => LeftSummand.Calculate() + RightSummand.Calculate();
        }

        private class BinaryMinusNode : Node
        {
            public Node Minuend { get; }
            public GroupNode Subtrahend { get; set; }

            public BinaryMinusNode(Node parent, Node minuend) : base(parent)
            {
                Minuend = minuend;
                minuend.Parent = this;
                Subtrahend = new GroupNode(this, false);
            }

            public override int Calculate() => Minuend.Calculate() - Subtrahend.Calculate();
        }

        private class UnaryMinusNode : Node
        {
            public GroupNode ChildNode { get; }

            public UnaryMinusNode(Node parent) : base(parent)
            {
                ChildNode = new GroupNode(this, false);
            }

            public override int Calculate() => -ChildNode.Calculate();
        }
    }
}
