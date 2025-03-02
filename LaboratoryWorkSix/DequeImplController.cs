using System.Text;
using LaboratoryWorkSix;

namespace LaboratoryWorkFive;

public class DequeImplController
{
    private DequeImpl<int> activeQueue;

    public void CreateQueue(int[] array)
    {
        activeQueue = new DequeImpl<int>(array);
    }

    public void Sort()
    {
        ThrowIfEmptyQueue();
        activeQueue.Sort(Comparer<int>.Default);
    }

    public GroupedDeque<int> GroupingByDigit()
    {
        ThrowIfEmptyQueue();
        return activeQueue.GroupingByDigit();
    }

    public string GetContentString()
    {
        ThrowIfEmptyQueue();
        int[] elements = activeQueue.ToArray();
        if (elements.Length > 0)
        {
            string startLine = "-----------\n";
            StringBuilder collect = new StringBuilder(startLine);

            foreach (int element in elements)
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
            throw new CollectionNullException();
        }
    }  
}