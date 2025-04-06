namespace LaboratoryWorkEight;

using System.Collections;
using System.Text;

public class DuLinkedListImpl<T> : IEnumerable<T>
{
    protected NodeListImpl<T> head;
    protected NodeListImpl<T> tail;
    protected int size = 0;

    public int Count => size;

    public IEnumerator<T> GetEnumerator()
    {
        return size > 0
            ? new LinkedListImplIEnumerator<T>(Copy(head))
            : new LinkedListImplIEnumerator<T>();
    }

    protected NodeListImpl<T> Copy<T>(NodeListImpl<T> node)
    {
        NodeListImpl<T> start = new NodeListImpl<T>(node);
        NodeListImpl<T> copiedNode = start.Next;
        while (copiedNode != null)
        {
            copiedNode = new NodeListImpl<T>(copiedNode);
            copiedNode = copiedNode.Next;
        }

        return start;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddFirst(T item)
    {
        if (head == null)
        {
            tail = head = new NodeListImpl<T>(item);
        }
        else
        {
            NodeListImpl<T> nextHead = new NodeListImpl<T>(item, head);
            head.Previous = nextHead;
            head = nextHead;
        }

        size = size + 1;
    }

    public void AddLast(T item)
    {
        if (head == null)
        {
            tail = head = new NodeListImpl<T>(item);
        }
        else
        {
            NodeListImpl<T> prevTail = tail;
            tail = new NodeListImpl<T>(prevTail, item);
            prevTail.Next = tail;
        }

        size = size + 1;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        NodeListImpl<T> currentNode = head;
        while (currentNode.Next != null)
        {
            stringBuilder.Append(currentNode.Data).Append(' ');
            currentNode = currentNode.Next;
        }

        return stringBuilder.ToString();
    }

    public string ToReversString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        NodeListImpl<T> currentNode = tail;
        while (currentNode.Previous != null)
        {
            stringBuilder.Append(currentNode.Data).Append(' ');
            currentNode = currentNode.Previous;
        }

        return stringBuilder.ToString();
    }

    public bool Contains(T item)
    {
        return FindIndex(item) != -1;
    }

    public int FindIndex(T item)
    {
        int index = 0;
        for (NodeListImpl<T> impl = head; impl != null; impl = impl.Next)
        {
            if (Object.Equals(item, impl.Data))
            {
                return index;
            }

            index = index + 1;
        }

        return -1;
    }

    public T GetAt(int index)
    {
        ThrowIfIndexOutOfRangeException(index);

        NodeListImpl<T> currentNode = GetNodeAt(index);
        return currentNode == null ? default(T) : currentNode.Data;
    }

    public T this[int i] => GetAt(i);

    protected NodeListImpl<T> GetNodeAt(int index)
    {
        ThrowIfIndexOutOfRangeException(index);
        NodeListImpl<T> currentNode;
        if (index < size / 2)
        {
            currentNode = head;
            for (int elementIndex = 0; elementIndex != index; elementIndex++)
            {
                currentNode = currentNode.Next;
            }
        }
        else
        {
            currentNode = tail;
            for (int elementIndex = 0; elementIndex != index; elementIndex++)
            {
                currentNode = currentNode.Previous;
            }
        }

        return currentNode;
    }

    protected void ThrowIfIndexOutOfRangeException(int index)
    {
        if (index < 0 || size <= index)
        {
            throw new IndexOutOfRangeException($"Индекс {index} вышел за пределы массива");
        }
    }

    public void InsertBefore(T item, int beforeIndex)
    {
        if (beforeIndex == 0)
        {
            AddFirst(item);
        }
        else
        {
            Insert(item, beforeIndex);
        }
    }

    public void InsertAfter(T item, int afterIndex)
    {
        if (afterIndex == size - 1)
        {
            AddLast(item);
        }
        else
        {
            Insert(item, afterIndex + 1);
        }
    }

    protected void Insert(T item, int index)
    {
        ThrowIfIndexOutOfRangeException(index);
        NodeListImpl<T> previousNode = GetNodeAt(index - 1);
        NodeListImpl<T> nextNode = previousNode.Next;
        NodeListImpl<T> currentNode = new NodeListImpl<T>(previousNode, item, nextNode);
        previousNode.Next = currentNode;
        nextNode.Previous = currentNode;
        size = size + 1;
    }

    protected void RemoveAt(int index)
    {
        ThrowIfIndexOutOfRangeException(index);
        if (index == 0)
        {
            head = head.Next;
            head.Previous = null;
        }
        else if (index == size - 1)
        {
            tail = GetNodeAt(index - 1);
            tail.Next = null;
        }
        else
        {
            NodeListImpl<T> nodePositionBack = GetNodeAt(index - 1);
            NodeListImpl<T> nodePositionForward = nodePositionBack.Next.Next;
            nodePositionBack.Next = nodePositionForward;
            nodePositionForward.Previous = nodePositionBack;
        }

        size = size - 1;
    }

    public void RemoveFirst()
    {
        RemoveAt(0);
    }

    public void RemoveLast()
    {
        RemoveAt(size - 1);
    }

    public void RemoveBefore(int indexBefore)
    {
        RemoveAt(indexBefore - 1);
    }

    public void RemoveAfter(int indexAfter)
    {
        RemoveAt(indexAfter + 1);
    }

    protected class NodeListImpl<T>
    {
        private T data;
        private NodeListImpl<T> previousNode;
        private NodeListImpl<T> nextNode;

        public NodeListImpl(NodeListImpl<T> node)
        {
            this.data = node.data;
            this.nextNode = node.nextNode;
            this.previousNode = node.previousNode;
        }

        public NodeListImpl(T data)
        {
            this.data = data;
        }

        public NodeListImpl(NodeListImpl<T> previousNode, T data)
        {
            this.previousNode = previousNode;
            this.data = data;
        }

        public NodeListImpl(T data, NodeListImpl<T> nextNode)
        {
            this.data = data;
            this.nextNode = nextNode;
        }

        public NodeListImpl(NodeListImpl<T> previousNode, T data, NodeListImpl<T> nextNode)
        {
            this.previousNode = previousNode;
            this.data = data;
            this.nextNode = nextNode;
        }

        public T Data
        {
            get => data;
            set => data = value;
        }

        public NodeListImpl<T> Previous
        {
            get => previousNode;
            set => previousNode = value;
        }

        public NodeListImpl<T> Next
        {
            get => nextNode;
            set => nextNode = value;
        }
    }

    protected class LinkedListImplIEnumerator<T> : IEnumerator<T>
    {
        private NodeListImpl<T> head;
        private NodeListImpl<T> currentNode;

        public LinkedListImplIEnumerator(NodeListImpl<T> head)
        {
            this.head = head;
        }

        public LinkedListImplIEnumerator()
        {
            this.head = null;
        }

        public bool MoveNext()
        {
            if (currentNode == null)
            {
                currentNode = head;
            }
            else
            {
                currentNode = currentNode.Next;
            }

            return currentNode != null;
        }

        public void Reset()
        {
            currentNode = null;
        }

        public T Current => currentNode.Data;

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}