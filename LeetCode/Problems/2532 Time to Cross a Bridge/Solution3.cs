using JetBrains.Annotations;

namespace LeetCode.Problems._2532_Time_to_Cross_a_Bridge;

/// <summary>
/// https://leetcode.com/submissions/detail/874330873/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int FindCrossingTime(int n, int k, int[][] time)
    {
        var workers = time.Select((arr, index) => new Worker(index, arr[0], arr[1], arr[2], arr[3])).ToArray();

        var leftBankQueue = new MinHeap<Worker>();
        var rightBankQueue = new MinHeap<Worker>();
        var oldWarehouseQueue = new MinHeap<Worker>();
        var newWarehouseQueue = new MinHeap<Worker>();
        var workerEventQueue = new MinHeap<Event>();
        var boxesCountInTheOldWarehouse = n;
        var boxesCountInTheNewWarehouse = 0;
        var freeBridgeTime = 0;

        foreach (var worker in workers)
        {
            leftBankQueue.Enqueue(worker);
        }

        workerEventQueue.Enqueue(new Event(0, null, null));

        while (true)
        {
            var workerEvent = workerEventQueue.Dequeue();
            workerEvent.MoveWorker();

            while (!workerEventQueue.IsEmpty())
            {
                var nextEvent = workerEventQueue.Peek();

                if (nextEvent.Time != workerEvent.Time)
                {
                    break;
                }

                workerEventQueue.Dequeue();
                nextEvent.MoveWorker();
            }

            while (!oldWarehouseQueue.IsEmpty())
            {
                var worker = oldWarehouseQueue.Dequeue();
                boxesCountInTheOldWarehouse--;
                workerEventQueue.Enqueue(new Event(workerEvent.Time + worker.PickOldBoxTime, worker, rightBankQueue));
            }

            while (!newWarehouseQueue.IsEmpty())
            {
                var worker = newWarehouseQueue.Dequeue();
                boxesCountInTheNewWarehouse++;

                if (boxesCountInTheNewWarehouse == n)
                {
                    return workerEvent.Time;
                }

                workerEventQueue.Enqueue(new Event(workerEvent.Time + worker.PutNewBoxTime, worker, leftBankQueue));
            }

            if (!rightBankQueue.IsEmpty() && workerEvent.Time >= freeBridgeTime)
            {
                var worker = rightBankQueue.Dequeue();
                freeBridgeTime = workerEvent.Time + worker.RightToLeftTime;
                workerEventQueue.Enqueue(new Event(freeBridgeTime, worker, newWarehouseQueue));
            }
            else if (!leftBankQueue.IsEmpty() && workerEvent.Time >= freeBridgeTime && boxesCountInTheOldWarehouse > 0)
            {
                var worker = leftBankQueue.Dequeue();
                freeBridgeTime = workerEvent.Time + worker.LeftToRightTime;
                workerEventQueue.Enqueue(new Event(freeBridgeTime, worker, oldWarehouseQueue));
            }
        }
    }

    private record Worker(int Index, int LeftToRightTime, int PickOldBoxTime, int RightToLeftTime,
        int PutNewBoxTime) : IComparable<Worker>
    {
        public int CompareTo(Worker? other) => Comparable.CompareChain(this, other, x => -(x.LeftToRightTime + x.RightToLeftTime), x => -x.Index);
    }

    private class MinHeap<TElement>
    {
        private readonly PriorityQueue<TElement, TElement> _queue = new();

        public void Enqueue(TElement element) => _queue.Enqueue(element, element);

        public TElement Dequeue() => _queue.Dequeue();

        public bool IsEmpty() => _queue.Count == 0;

        public TElement Peek() => _queue.Peek();
    }

    private record Event(int Time, Worker? Worker, MinHeap<Worker>? Queue) : IComparable<Event>
    {
        public int CompareTo(Event? other) => Comparable.CompareChain(this, other, x => x.Time);

        public void MoveWorker() => Queue?.Enqueue(Worker!);
    }

    private static class Comparable
    {
        public static int CompareChain<T>(T? left, T? right, params Func<T, IComparable>[] keyComparers)
        {
            if (Equals(left, right))
            {
                return 0;
            }

            if (left == null)
            {
                return -1;
            }

            if (right == null)
            {
                return 1;
            }

            return (from keyComparer in keyComparers
                    let keyLeft = keyComparer(left)
                    let keyRight = keyComparer(right)
                    select keyLeft.CompareTo(keyRight)).FirstOrDefault(result => result != 0);
        }
    }
}
