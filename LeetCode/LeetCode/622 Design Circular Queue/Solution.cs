namespace LeetCode._622_Design_Circular_Queue;

public class Solution : ISolution
{
    public IMyCircularQueue Create(int k)
    {
        return new MyCircularQueue(k);
    }
}