namespace LaboratoryWorkTwo;

public class TimSorter
{
    private int[] sortableArray;
    private int minrun;

    private Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();
    private int headOfStack = 0;

    private const int UPPER_BOUND_OF_UNCOMPUTABLE_N = 64;

    public TimSorter(int[] sortableArray)
    {
        this.sortableArray = sortableArray;
    }

    public int[] Sort()
    {
        if (sortableArray.Length < 2)
        {
            return sortableArray.ToArray();
        }

        minrun = CalculateMinrun();
        SplittingAnArray();
        MergeStack();
        return sortableArray;
    }

    private int CalculateMinrun()
    {
        int length = sortableArray.Length;

        if (length < UPPER_BOUND_OF_UNCOMPUTABLE_N)
        {
            return length;
        }

        int additionalUnit = 0;
        while (length >= UPPER_BOUND_OF_UNCOMPUTABLE_N)
        {
            additionalUnit = additionalUnit | (length & 1);
            length = length >> 1;
        }

        return length + additionalUnit;
    }

    private void SplittingAnArray()
    {
        int runStartIndex = 0;
        int indexInRun = 2;

        SwapIfGrates(0, 1);

        for (int i = indexInRun; i < sortableArray.Length; i++)
        {
            if (minrun > indexInRun)
            {
                SetByBin(runStartIndex, i);
                indexInRun = indexInRun + 1;

                if (i == sortableArray.Length - 1)
                {
                    AddInStack(runStartIndex, i - runStartIndex + 1);
                }
            }
            else if (IsGrater(i - 2, i - 1) == IsGrater(i - 1, i))
            {
                indexInRun = indexInRun + 1;

                if (i == sortableArray.Length - 1)
                {
                    AddInStack(runStartIndex, i - runStartIndex + 1);
                }
            }
            else
            {
                AddInStack(runStartIndex, i - runStartIndex);
                runStartIndex = i;
                SwapIfGrates(i, i + 1);
                indexInRun = 2;
                i = i - 1 + 2;
            }
        }
    }

    private bool IsGrater(int indexFirst, int indexSecond)
    {
        return sortableArray[indexFirst] <= sortableArray[indexSecond];
    }

    private void SwapIfGrates(int fist, int second)
    {
        if (sortableArray[fist] > sortableArray[second])
        {
            (sortableArray[fist], sortableArray[second]) = (sortableArray[second], sortableArray[fist]);
        }
    }

    private void SetByBin(int startIndex, int elementIndex)
    {
        int element = sortableArray[elementIndex];
        int sortIndex = elementIndex - 1;

        while (sortIndex >= startIndex && sortableArray[sortIndex] > element)
        {
            sortableArray[sortIndex + 1] = sortableArray[sortIndex];
            sortIndex = sortIndex - 1;
        }

        sortableArray[sortIndex + 1] = element;
    }

    private void AddInStack(int run, int size)
    {
        KeyValuePair<int, int> Z = new KeyValuePair<int, int>(run, size);
        stack.Push(Z);

        while (!CheckStack())
        {
            FixStack();
        }
    }

    private bool CheckStack()
    {
        int stackCount = stack.Count > 2 ? 3 : stack.Count;
        KeyValuePair<int, int>[] firstPairs = new KeyValuePair<int, int>[stackCount];

        for (int i = 0; i < stackCount; i++)
        {
            firstPairs[i] = stack.Pop();
        }

        for (int lastIndex = stackCount - 1; lastIndex >= 0; lastIndex--)
        {
            stack.Push(firstPairs[lastIndex]);
        }

        return stackCount switch
        {
            > 2 when !(firstPairs[2].Value > firstPairs[0].Value + firstPairs[1].Value) => false,
            <= 1 => true,
            _ => firstPairs[1].Value > firstPairs[0].Value
        };
    }

    private void FixStack()
    {
        int stackCount = stack.Count > 2 ? 3 : stack.Count;
        int lowerLimit = 0;
        KeyValuePair<int, int>[] firstPairs = new KeyValuePair<int, int>[stackCount];

        for (int i = 0; i < stackCount; i++)
        {
            firstPairs[i] = stack.Pop();
        }

        if (stackCount == 2)
        {
            if (!(firstPairs[1].Value > firstPairs[0].Value))
            {
                firstPairs[1] = Merge(firstPairs[1], firstPairs[0]);
                lowerLimit = lowerLimit + 1;
            }
        }
        else if (stackCount > 2)
        {
            if (!(firstPairs[1].Value > firstPairs[0].Value
                  && firstPairs[2].Value > firstPairs[1].Value + firstPairs[0].Value))
            {
                if (firstPairs[2].Value > firstPairs[0].Value)
                {
                    firstPairs[1] = Merge(firstPairs[1], firstPairs[0]);
                }
                else
                {
                    firstPairs[2] = Merge(firstPairs[2], firstPairs[1]);
                    firstPairs[1] = firstPairs[0];
                }

                lowerLimit = lowerLimit + 1;
            }
        }

        for (int lastIndex = stackCount - 1; lastIndex >= lowerLimit; lastIndex--)
        {
            stack.Push(firstPairs[lastIndex]);
        }
    }

    private void MergeStack()
    {
        while (stack.Count > 1)
        {
            KeyValuePair<int, int> first = stack.Pop();
            if (stack.TryPop(out var second))
            {
                second = Merge(second, first);
                stack.Push(second);
            }
            else
            {
                stack.Push(first);
            }
        }
    }

    private KeyValuePair<int, int> Merge(KeyValuePair<int, int> Y, KeyValuePair<int, int> Z)
    {
        int startRun = Math.Min(Y.Key, Z.Key);
        int indexRun = startRun;
        int mergeSize = Y.Value + Z.Value;
        int size = Y.Value + Z.Value + startRun;
        int corretteY = 0;
        int corretteZ = 0;
        int[] runY = new int[Y.Value];
        int[] runZ = new int[Z.Value];

        int isFinish = 0;

        Copy(sortableArray, Y.Key, runY, 0, Y.Value);
        Copy(sortableArray, Z.Key, runZ, 0, Z.Value);

        while (indexRun < size)
        {
            int elementY = runY[corretteY];
            int elementZ = runZ[corretteZ];

            if (elementY <= elementZ)
            {
                sortableArray[indexRun] = elementY;
                corretteY = corretteY + 1;
            }
            else
            {
                sortableArray[indexRun] = elementZ;
                corretteZ = corretteZ + 1;
            }

            indexRun = indexRun + 1;
            isFinish = corretteY == runY.Length ? 1 :
                corretteZ == runZ.Length ? 2 : 0;

            if (isFinish != 0)
            {
                break;
            }
        }

        switch (isFinish)
        {
            case 1:
                Copy(runZ, corretteZ, sortableArray, indexRun, size - indexRun);
                break;
            case 2:
                Copy(runY, corretteY, sortableArray, indexRun, size - indexRun);
                break;
        }

        return new KeyValuePair<int, int>(startRun, mergeSize);
    }

    private void Copy(int[] sourceArray, int sourceIndex, int[] recipient, int recipientStartIndex, int lenght)
    {
        for (int i = 0; i < lenght; i++)
        {
            recipient[recipientStartIndex] = sourceArray[sourceIndex];
            sourceIndex = sourceIndex + 1;
            recipientStartIndex = recipientStartIndex + 1;
        }
    }
}