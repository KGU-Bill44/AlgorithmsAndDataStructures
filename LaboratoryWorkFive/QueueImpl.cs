using System.Collections;

namespace LaboratoryWorkFive;

public class QueueImpl<T> : IEnumerable<T>
{
    private T[] items;
    private int size;
    private int tail;
    private int head;

    public QueueImpl()
    {
        size = 0;
        items = new T[10];
        head = tail = 0;
    }

    public QueueImpl(T[] items)
    {
        head = 0;
        size = items.Length;
        tail = size;
        this.items = items;
    }

    public void Push(T item)
    {
        if (IsArrayOverflowing())
        {
            Increase();
        }

        items[tail] = item;
        MoveNext(ref tail);
        size = size + 1;
        
    }

    private bool IsArrayOverflowing()
    {
        return size == items.Length;
    }

    private void Increase()
    {
        int newSize = items.Length + items.Length / 2;
        T[] nextItems = new T[newSize];

        if (head < tail)
        {
            Array.Copy(items, head, nextItems, 0, size);
        }
        else
        {
            Array.Copy(items, head, nextItems, 0, size - head);
            Array.Copy(items, 0, nextItems, size - head, tail);
        }

        items = nextItems;
        tail = size;
        head = 0;
    }

    private void MoveNext(ref int index)
    {
        if (index < items.Length - 1)
        {
            index = index + 1;
        }
        else
        {
            index = 0;
        }
    }

    public T Take()
    {
        T item = items[head];
        items[head] = default;
        MoveNext(ref head);
        size = size - 1;

        return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new QueueIEnumeratorImpl(items);
    }
    
    private class QueueIEnumeratorImpl : IEnumerator<T>
    {
        private T[] array;
        private int currentIndex;
        
        public QueueIEnumeratorImpl(T[] array)
        {
            this.array = array;
            currentIndex = 0;
        }


        public bool MoveNext()
        {
            currentIndex = currentIndex + 1;
            return currentIndex < array.Length;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        object? IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public T Current => array[currentIndex];
    }
}