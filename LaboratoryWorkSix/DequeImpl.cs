using System.Collections;

namespace LaboratoryWorkSix;

public class DequeImpl<T> : IEnumerable<T>
{
    private DequeImplItemNode head;
    private DequeImplItemNode tail;

    private DequeImplItemNode emptyNode;

    private int size;

    public DequeImpl()
    {
        Clear();
    }

    public DequeImpl(T startItem)
    {
        tail = head = new DequeImplItemNode(startItem);
        size = 1;
    }

    public DequeImpl(T[] array) : this()
    {
        this.ToAccept(array);
    }

    public void InsertFirst(T item)
    {
        head = new DequeImplItemNode(item, null, head);
        head.Next.Previous = head;
        size = size + 1;
    }

    public void InsertLast(T item)
    {
        tail = new DequeImplItemNode(item, tail, null);
        tail.Previous.Next = tail;
        size = size + 1;
    }

    public T TakeFirst()
    {
        if (IsEmpty())
        {
            throw new CollectionEmptyException();
        }

        T retItem = head.Item;
        head = head.Next;
        head.Previous = null;
        size = size - 1;

        return retItem;
    }

    public T TakeLast()
    {
        if (IsEmpty())
        {
            throw new CollectionEmptyException();
        }

        T retItem = tail.Item;
        tail = tail.Previous;
        tail.Previous = null;
        size = size - 1;

        return retItem;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public T[] ToArray()
    {
        T[] array = new T[size];

        DequeImplItemNode node = head;

        for (int itemIndex = 0; itemIndex < size; itemIndex++)
        {
            if (emptyNode == node)
            {
                itemIndex = itemIndex - 1;
                node = node.Next;
                continue;
            }
                

            array[itemIndex] = node.Item;
            node = node.Next;
        }

        return array;
    }

    public void Clear()
    {
        emptyNode = tail = head = new DequeImplItemNode(null, null);
        size = 0;
    }

    public void ToAccept(T[] array)
    {
        foreach (T item in array)
        {
            this.InsertLast(item);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new DequeImplIteEnumerator<T>(this.ToArray());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private class DequeImplItemNode
    {
        private T item;

        public DequeImplItemNode(T item)
        {
            this.item = item;
        }

        public DequeImplItemNode(T item, DequeImplItemNode previous, DequeImplItemNode next)
        {
            this.item = item;
            this.Next = next;
            this.Previous = previous;
        }

        public DequeImplItemNode(DequeImplItemNode previous, DequeImplItemNode next)
            : this(default, previous, next)
        {
        }

        public T Item
        {
            get => item;
            set => item = value;
        }

        public DequeImplItemNode Next { get; set; }

        public DequeImplItemNode Previous { get; set; }
    }

    private class DequeImplIteEnumerator<T> : IEnumerator<T>
    {
        private T[] innerArrays;
        private int position = -1;

        public DequeImplIteEnumerator(T[] arrays)
        {
            this.innerArrays = arrays;
        }

        public bool MoveNext()
        {
            position = position + 1;
            return position < innerArrays.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public object? Current => innerArrays[position];

        T IEnumerator<T>.Current => innerArrays[position];

        public void Dispose()
        {
        }
    }
}