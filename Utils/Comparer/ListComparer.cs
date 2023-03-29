using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Login.Utils.Comparer;

// Custom collection value comparer to compare the elements in the set
public class HashSetComparer<T> : ValueComparer<HashSet<T>>
{
    public HashSetComparer()
        : base(
            // Compare method: return true if both collections contain the same elements
            (c1, c2) => c1.SequenceEqual(c2),
            // Hash code method: generate hash code based on the hash code of the elements
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            // Snapshot method: create a snapshot of the collection by creating a new set with the same elements
            c => c.Select(v => v).ToHashSet()
        ) { }
}
