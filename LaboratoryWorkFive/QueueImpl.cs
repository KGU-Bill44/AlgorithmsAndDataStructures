namespace LaboratoryWorkFive;

public class QueueImpl<T>
{
    private T[] items;
    private int size;
    private int tail;
    private int head;

    public QueueImpl()
    {
        
    }

    public QueueImpl(T[] items)
    {
        head = 0;
        size = items.Length;
        tail = size - 1;
        this.items = items;
    }

    public void Push(T item)
    {
        tail = tail + 1;
        
        if (size - head <= tail)
        {
            size = size / 2 + size;
            Array.Resize(ref items, size);
        }
    }

    private void SetItem(T item, int tail)
    {
        items[tail] = item;
    }

    public T Take()
    {
        T item = items[head];
        head = head - 1;
        size = size - 1;
        return item;
    }
}