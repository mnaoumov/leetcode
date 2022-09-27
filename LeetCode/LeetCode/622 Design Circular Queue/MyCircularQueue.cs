﻿namespace LeetCode._622_Design_Circular_Queue;

/// <summary>
/// https://leetcode.com/submissions/detail/807894085/
/// </summary>
public class MyCircularQueue : IMyCircularQueue
{
    private readonly int[] _values;
    private int _frontElementIndex;
    private int _rearElementIndex;
    private int _count;

    public MyCircularQueue(int k)
    {
        _values = new int[k];
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
        {
            return false;
        }

        if (!IsEmpty())
        {
            IncreaseIndexCircularly(ref _rearElementIndex);
        }

        _values[_rearElementIndex] = value;
        _count++;
        return true;
    }

    private void IncreaseIndexCircularly(ref int index)
    {
        index++;
        if (index >= _values.Length)
        {
            index = 0;
        }
    }

    public bool DeQueue()
    {
        if (IsEmpty())
        {
            return false;
        }

        IncreaseIndexCircularly(ref _frontElementIndex);
        _count--;

        if (IsEmpty())
        {
            _frontElementIndex = _rearElementIndex = 0;
        }

        return true;
    }

    public int Front()
    {
        return IsEmpty() ? -1 : _values[_frontElementIndex];
    }

    public int Rear()
    {
        return IsEmpty() ? -1 : _values[_rearElementIndex];
    }

    public bool IsEmpty()
    {
        return _count == 0;
    }

    public bool IsFull()
    {
        return _count == _values.Length;
    }
}
