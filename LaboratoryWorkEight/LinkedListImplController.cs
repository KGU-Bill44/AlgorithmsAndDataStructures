namespace  LaboratoryWorkEight;

public class LinkedListImplController<T>
{
    private DuLinkedListImpl<T> list;

    public void CreateList()
    {
        list = new DuLinkedListImpl<T>();
    }

    public void AddElementFirst(T number)
    {
        ThrowIfListNotExist();
        list.AddFirst(number);
    }

    public void AddElementLast(T number)
    {
        ThrowIfListNotExist();
        list.AddLast(number);
    }

    public string GetListString()
    {
        ThrowIfListNotExist();
        return list.ToString();
    }
    
    public string GetReversListString()
    {
        ThrowIfListNotExist();
        return list.ToReversString();
    }

    public bool Contains(T number)
    {
        ThrowIfListNotExist();
        return list.Contains(number);
    }

    public T GetAt(int index)
    {
        ThrowIfListNotExist();
        return list.GetAt(index);
    }

    public void InsertBefore(T element, int index)
    {
        ThrowIfListNotExist();
        list.InsertBefore(element, index);
    }

    public void InsertAfter(T element, int index)
    {
        ThrowIfListNotExist();
        list.InsertAfter(element, index);
    }

    public void RemoveFirst()
    {
        ThrowIfListNotExist();
        list.RemoveFirst();
    }

    public void RemoveLast()
    {
        ThrowIfListNotExist();
        list.RemoveLast();
    }

    public void RemoveBefore(int index)
    {
        ThrowIfListNotExist();
        list.RemoveBefore(index);
    }

    public void RemoveAfter(int index)
    {
        ThrowIfListNotExist();
        list.RemoveAfter(index);
    }

    public void RemoveEqualNeighbors()
    {
        ThrowIfListNotExist();
    }

    private void ThrowIfListNotExist()
    {
        if (list == null)
        {
            throw new ListNotExistException();
        }
    }

    public void InsertIfEven(T element)
    {
        
    }
}