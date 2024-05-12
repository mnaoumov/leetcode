using JetBrains.Annotations;

namespace LeetCode._2532_Time_to_Cross_a_Bridge;

/// <summary>
/// https://leetcode.com/submissions/detail/874261425/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int FindCrossingTime(int n, int k, int[][] time)
    {
        var workers = time.Select((arr, index) => new Worker(index, arr[0], arr[1], arr[2], arr[3])).ToArray();

        var pq = new PriorityQueue<Entry, Entry>();

        foreach (var worker in workers)
        {
            var entry = new Entry(0, worker, Location.LeftBankOfTheBridge);
            pq.Enqueue(entry, entry);
        }

        var nextTimeBridgeIsEmpty = 0;
        var boxesCountInTheOldWarehouse = n;
        var boxesCountInTheNewWarehouse = 0;

        while (true)
        {
            var entry = pq.Dequeue();

            Entry nextEntry;

            switch (entry.Location)
            {
                case Location.RightBankOfTheBridge:
                    if (entry.Time < nextTimeBridgeIsEmpty)
                    {
                        nextEntry = entry with { Time = nextTimeBridgeIsEmpty };
                    }
                    else
                    {
                        nextTimeBridgeIsEmpty = entry.Time + entry.Worker.RightToLeftTime;
                        nextEntry = entry with { Time = nextTimeBridgeIsEmpty, Location = Location.NewWarehouse };
                    }
                    break;
                case Location.LeftBankOfTheBridge:
                    if (entry.Time < nextTimeBridgeIsEmpty)
                    {
                        nextEntry = entry with { Time = nextTimeBridgeIsEmpty };
                    }
                    else if (boxesCountInTheOldWarehouse == 0)
                    {
                        nextEntry = entry with { Time = int.MaxValue };
                    }
                    else
                    {
                        nextTimeBridgeIsEmpty = entry.Time + entry.Worker.LeftToRightTime;
                        nextEntry = entry with { Time = nextTimeBridgeIsEmpty, Location = Location.OldWarehouse };
                    }
                    break;
                case Location.OldWarehouse:
                    if (boxesCountInTheOldWarehouse > 0)
                    {
                        boxesCountInTheOldWarehouse--;
                        nextEntry = entry with
                        {
                            Time = entry.Time + entry.Worker.PickOldBoxTime,
                            Location = Location.RightBankOfTheBridge
                        };
                    }
                    else
                    {
                        nextEntry = entry with
                        {
                            Location = Location.RightBankOfTheBridge
                        };
                    }
                    break;
                case Location.NewWarehouse:
                    boxesCountInTheNewWarehouse++;

                    if (boxesCountInTheNewWarehouse == n)
                    {
                        return entry.Time;
                    }

                    nextEntry = entry with
                    {
                        Time = entry.Time + entry.Worker.PutNewBoxTime,
                        Location = Location.LeftBankOfTheBridge
                    };

                    break;
                default:
                    throw new ArgumentOutOfRangeException("", default(Exception));
            }

            pq.Enqueue(nextEntry, nextEntry);
        }
    }

    private record Worker(int Index, int LeftToRightTime, int PickOldBoxTime, int RightToLeftTime, int PutNewBoxTime);

    private enum Location
    {
        OldWarehouse,
        NewWarehouse,
        RightBankOfTheBridge,
        LeftBankOfTheBridge
    }

    private record Entry(int Time, Worker Worker, Location Location) : IComparable<Entry>
    {
        public int CompareTo(Entry? other) =>
            CompareChain(this, other, x => x.Time, x => x.Location,
                x => -(x.Worker.LeftToRightTime + x.Worker.RightToLeftTime), x => x.Worker.Index);

        private static int CompareChain<T>(T? left, T? right, params Func<T, IComparable>[] keyComparers)
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
