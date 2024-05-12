namespace LeetCode._1634_Add_Two_Polynomials_Represented_as_Linked_Lists
{
    public class PolyNode : IEquatable<PolyNode>
    {
        // ReSharper disable once InconsistentNaming
        public readonly int coefficient;

        // ReSharper disable once InconsistentNaming
        public readonly int power;

        // ReSharper disable once InconsistentNaming
        public PolyNode? next;

        public PolyNode(int x = 0, int y = 0, PolyNode? next = null)
        {
            coefficient = x;
            power = y;
            this.next = next;
        }

        public static PolyNode? CreateOrNull(IEnumerable<int[]> values)
        {
            var fakeRoot = new PolyNode();
            var node = fakeRoot;

            foreach (var arr in values)
            {
                node.next = new PolyNode(arr[0], arr[1]);
                node = node.next;
            }

            return fakeRoot.next;
        }

        public bool Equals(PolyNode? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return coefficient == other.coefficient && power == other.power && Equals(next, other.next);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((PolyNode) obj);
        }

        // ReSharper disable NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => HashCode.Combine(coefficient, power, next);
        // ReSharper restore NonReadonlyMemberInGetHashCode

        public override string ToString()
        {
            var sign = coefficient > 0 ? "+" : "";
            return $"{sign}{coefficient}x^{power}{next}";
        }
    }
}
