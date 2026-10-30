using System.Runtime.CompilerServices;

namespace LeetCode.DataStructure;

/// <summary>
/// Compares pairs of nodes by reference, so a structural comparison can remember which pairs it has already visited.
/// </summary>
[PublicAPI]
public sealed class ReferencePairComparer<T> : IEqualityComparer<(T, T)> where T : class
{
    public static readonly ReferencePairComparer<T> Instance = new();

    public bool Equals((T, T) x, (T, T) y) => ReferenceEquals(x.Item1, y.Item1) && ReferenceEquals(x.Item2, y.Item2);

    public int GetHashCode((T, T) obj) => HashCode.Combine(RuntimeHelpers.GetHashCode(obj.Item1), RuntimeHelpers.GetHashCode(obj.Item2));
}
