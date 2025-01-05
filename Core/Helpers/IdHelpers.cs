using Core.Interface;

namespace Core.Helpers;

public class IdHelpers : IIdHelpers
{
    public Guid CreateGuid()
    {
        return Guid.NewGuid();
    }

    /// <summary>
    /// Generated with AI Claude 3.5 Sonnet 100%.
    ///
    /// Gets the next available ID for a collection by finding the maximum existing ID and adding 1.
    /// If the collection is null or empty, returns 1 as the starting ID.
    ///
    /// Features:
    /// - Safely handles null or empty collections
    /// - Performs single enumeration for performance
    /// - Works with any collection type that implements IEnumerable&lt;T&gt;
    /// - Generic implementation allows reuse across different entity types
    ///
    /// Example usage:
    /// var nextId = GetNextId(users, user => user.Id);
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection</typeparam>
    /// <param name="collection">The source collection to analyze. Can be null.</param>
    /// <param name="idSelector">A function to extract the ID from each element</param>
    /// <returns>Returns the next available ID (max + 1), or 1 if the collection is null or empty</returns>
    public int GetNextId<T>(IEnumerable<T>? collection, Func<T, int> idSelector)
    {
        if (collection == null)
            return 1;

        var items = collection.ToList(); // Enumerate only once
        return items.Count > 0
            ? items.Max(idSelector) + 1
            : 1;
    }
}