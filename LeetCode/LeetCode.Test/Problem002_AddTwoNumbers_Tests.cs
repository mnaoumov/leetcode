using System.Collections.Generic;
using LeetCode.Problem002_AddTwoNumbers;
using NUnit.Framework;

namespace LeetCode.Test
{
    [TestFixture(typeof(Solution))]
    public class Problem002_AddTwoNumbers_Tests<TSolution> where TSolution : ISolution, new()
    {
        [Test]
        [TestCase(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
        public void Test(int[] l1Values, int[] l2Values, int[] expectedResultValues)
        {
            var solution = new TSolution();
            var result = solution.AddTwoNumbers(CreateNode(l1Values), CreateNode(l2Values));
            Assert.That(ExtractValues(result), Is.EquivalentTo(expectedResultValues));
        }

        private static int[] ExtractValues(ListNode listNode)
        {
            var values = new List<int>();
            while (listNode != null)
            {
                values.Add(listNode.val);
                listNode = listNode.next;
            }

            return values.ToArray();
        }

        private static ListNode CreateNode(int[] values)
        {
            ListNode lastNode = null;
            ListNode firstNode = null;
            foreach (var value in values)
            {
                var node = new ListNode(value);
                if (lastNode != null)
                    lastNode.next = node;
                else
                    firstNode = node;
                lastNode = node;
            }

            return firstNode;
        }
    }
}