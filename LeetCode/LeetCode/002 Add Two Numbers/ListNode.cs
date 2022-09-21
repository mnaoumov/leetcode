﻿namespace LeetCode._002_Add_Two_Numbers;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ListNode listNode)
        {
            return false;
        }

        return val == listNode.val && Equals(next, listNode.next);
    }

    public override string ToString()
    {
        var values = new List<int>();
        var listNode = this;
        while (listNode != null)
        {
            values.Add(listNode.val);
            listNode = listNode.next;
        }

        return $"[{string.Join(",", values)}]";
    }
}