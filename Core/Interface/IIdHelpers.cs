namespace Core.Interface;

public interface IIdHelpers
{
    public Guid CreateGuid();
    public int GetNextId<T>(IEnumerable<T>? collection, Func<T, int> idSelector);
}