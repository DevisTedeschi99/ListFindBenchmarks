namespace List.Find.Benchmarks;

public class RefactoredList<T>
{
    public RefactoredList(IEnumerable<T> items)
    {
        _items = items.ToArray();
    }

    internal T[] _items;

    public T? Find(Predicate<T> predicate)
    {
        if (predicate == null)
        {
            throw new Exception();
        }

        ReadOnlySpan<T> span = new ReadOnlySpan<T>(_items);
        foreach (T element in span)
        {
            if (predicate(element))
            {
                return element;
            }
        }

        return default;
    }
    
    public List<T> FindAll(Predicate<T> match)
    {
        if (match == null)
        {
            throw new Exception();
        }

        List<T> list = new List<T>();
        ReadOnlySpan<T> span = new ReadOnlySpan<T>(_items);
        foreach (T element in span)
        {
            if (match(element))
            {
                list.Add(element);
            }
        }
        return list;
    }
}