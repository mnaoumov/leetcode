namespace LeetCode.Problem002_AddTwoNumbers
{
    public class Solution : ISolution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var fakeHeadNode = new ListNode(0);
            bool hasCarry = false;
            var lastNode = fakeHeadNode;

            while (l1 != null || l2 != null || hasCarry)
            {
                var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + (hasCarry ? 1 : 0);
                l1 = l1?.next;
                l2 = l2?.next;
                hasCarry = sum >= 10;
                if (hasCarry)
                    sum -= 10;

                lastNode.next = new ListNode(sum);
                lastNode = lastNode.next;
            }

            return fakeHeadNode.next;
        }
    }
}