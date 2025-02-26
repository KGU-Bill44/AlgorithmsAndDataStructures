using System.Numerics;
using System.Text;

namespace LaboratoryWorkFive;

public class QueueImplController<T> where T : IMultiplyOperators<T, T, T>
{
    private QueueImpl<T> activeQueue;

    public void CreateQueue(T[] array)
    {
        activeQueue = new QueueImpl<T>(array);
    }

    public bool Includes(T[] array)
    {
        ThrowIfEmptyQueue();
        QueueImpl<T> sample = new QueueImpl<T>(array);
        return activeQueue.Includes(sample);
    }

    public void Scale(T scaler)
    {
        ThrowIfEmptyQueue();
        activeQueue.Scale(scaler);
    }

    public string GetStackContentString()
    {
        ThrowIfEmptyQueue();
        T[] elements = activeQueue.ToArray();
        if (elements.Length > 0)
        {
            string startLine = "-----------\n";
            StringBuilder collect = new StringBuilder(startLine);

            foreach (T element in elements)
            {
                collect.Append($"|   {element}\t  |\n" +
                               "-----------\n");
            }

            return collect.ToString();
        }
        else
        {
            return String.Empty;
        }
    }

    private void ThrowIfEmptyQueue()
    {
        if (activeQueue == null)
        {
            throw new EmptyControllerException();
        }
    }  
}