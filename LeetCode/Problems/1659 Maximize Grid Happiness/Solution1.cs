using System.Collections;
using JetBrains.Annotations;

namespace LeetCode._1659_Maximize_Grid_Happiness;

/// <summary>
/// https://leetcode.com/submissions/detail/919268040/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const int IntrovertInitialHappiness = 120;
    private const int ExtrovertInitialHappiness = 40;
    private const int IntrovertHappinessChangePerNeighbor = -30;
    private const int ExtrovertHappinessChangePerNeighbor = 20;

    public int GetMaxGridHappiness(int m, int n, int introvertsCount, int extrovertsCount)
    {
        var dp =
            new DynamicProgramming<(int cellIndex, int introvertsLeft, int extrovertsLeft, HashableImmutableArray<State> previousNStates), int>(
                (key, recursiveFunc) =>
                {
                    var (cellIndex, introvertsLeft, extrovertsLeft, previousNStates) = key;

                    var row = cellIndex / n;
                    var column = cellIndex % n;

                    if (row == m)
                    {
                        return 0;
                    }

                    if (introvertsLeft == 0 && extrovertsLeft == 0)
                    {
                        return 0;
                    }

                    var leftCellState = column == 0 ? State.Empty : previousNStates[n - 1];
                    var topCellState = row == 0 ? State.Empty : previousNStates[0];
                    var neighborsHappinessChange = HappinessChangePerNeighbor(leftCellState) + HappinessChangePerNeighbor(topCellState);
                    var nonEmptyNeighborCellsCount = NonEmptyCount(leftCellState) + NonEmptyCount(topCellState);

                    var result = 0;

                    foreach (var state in Enum.GetValues<State>())
                    {
                        var nextNStates = new HashableImmutableArray<State>(previousNStates.Skip(1).Append(state));

                        switch (state)
                        {
                            case State.Empty:
                                result = Math.Max(result,
                                    recursiveFunc((cellIndex + 1, introvertsLeft, extrovertsLeft, nextNStates)));
                                break;
                            case State.Introvert:
                                if (introvertsLeft > 0)
                                {
                                    result = Math.Max(result,
                                        neighborsHappinessChange + IntrovertInitialHappiness + HappinessChangePerNeighbor(state) * nonEmptyNeighborCellsCount +
                                        recursiveFunc((cellIndex + 1, introvertsLeft - 1, extrovertsLeft,
                                            nextNStates)));
                                }
                                break;
                            case State.Extrovert:
                                if (extrovertsLeft > 0)
                                {
                                    result = Math.Max(result,
                                        neighborsHappinessChange + ExtrovertInitialHappiness + HappinessChangePerNeighbor(state) * nonEmptyNeighborCellsCount +
                                        recursiveFunc((cellIndex + 1, introvertsLeft, extrovertsLeft - 1,
                                            nextNStates)));
                                }
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }

                    return result;
                });

        return dp.GetOrCalculate((0, introvertsCount, extrovertsCount,
            new HashableImmutableArray<State>(Enumerable.Repeat(State.Empty, n))));
    }

    private static int NonEmptyCount(State state) => state == State.Empty ? 0 : 1;

    private static int HappinessChangePerNeighbor(State state) =>
        state switch
        {
            State.Empty => 0,
            State.Introvert => IntrovertHappinessChangePerNeighbor,
            State.Extrovert => ExtrovertHappinessChangePerNeighbor,
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
        };

    private class HashableImmutableArray<T> : IReadOnlyList<T>
    {
        private readonly T[] _items;
        public HashableImmutableArray(IEnumerable<T> items) => _items = items.ToArray();

        public override int GetHashCode() => (_items as IStructuralEquatable).GetHashCode(EqualityComparer<T>.Default);

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) ||
            obj is HashableImmutableArray<T> other && _items.SequenceEqual(other._items);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        // ReSharper disable once NotDisposedResourceIsReturned
        public IEnumerator<T> GetEnumerator() => _items.AsEnumerable().GetEnumerator();
        public int Count => _items.Length;
        public T this[int index] => _items[index];
    }

    private enum State
    {
        Empty,
        Introvert,
        Extrovert
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
