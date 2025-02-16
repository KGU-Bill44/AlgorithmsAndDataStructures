namespace LaboratoryWorkFour;

internal class Engin
{
    private Stack<int> mainStack;
    private Random random;

    public Engin()
    {
        mainStack = new Stack<int>();
        random = new Random();
    }

    public static Engin CreateEngin()
    {
        return new Engin();
    }

    public void FillStackRandomInts(int length, int upperLimit = 0,
        int lowerLimit = 100)
    {
        for (int i = 0; i < length; i++)
        {
            mainStack.Push(random.Next(upperLimit, lowerLimit + 1));
        }
    }

    public void PutMaximumAtEnd()
    {
        if (mainStack.Count > 1)
        {
            int[] heap = mainStack.ToArray();
            mainStack.Clear();
            int max = heap[0];
            int indexOfMax = 0;

            for (int i = heap.Length - 1; i > -1; i--)
            {
                int element = heap[i];
                if (element > max)
                {
                    max = element;
                    indexOfMax = i;
                }
            }

            mainStack.Push(heap[indexOfMax]);
            for (int i = heap.Length - 1; i > -1; i--)
            {
                if (i == indexOfMax) continue;

                mainStack.Push(heap[i]);
            }
        }
    }

    public void PutMinimumAtFirst()
    {
        if (mainStack.Count > 1)
        {
            int[] heap = mainStack.ToArray();
            mainStack.Clear();
            int min = heap[0];
            int indexOfMin = 0;

            for (int i = heap.Length - 1; i > -1; i--)
            {
                int element = heap[i];
                if (element < min)
                {
                    min = element;
                    indexOfMin = i;
                }
            }

            for (int i = heap.Length - 1; i > -1; i--)
            {
                if (i == indexOfMin) continue;

                mainStack.Push(heap[i]);
            }
            mainStack.Push(heap[indexOfMin]);
        }
    }

    public int[] GetElementsOfStack()
    {
        return mainStack.ToArray();
    }
}