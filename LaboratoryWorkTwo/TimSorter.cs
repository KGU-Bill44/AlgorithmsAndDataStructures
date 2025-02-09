namespace LaboratoryWorkTwo;

public class TimSorter
{
    private List<int> sortableArray;
    private int minrun;
    private List<List<int>> runs = new List<List<int>>();

    private const int UPPER_BOUND_OF_UNCOMPUTABLE_N = 64;

    public TimSorter(int[] sortableArray)
    {
        this.sortableArray = new List<int>(sortableArray);
    }

    public int[] Sort()
    {
        if (sortableArray.Count < 2)
        {
            return sortableArray.ToArray();
        }

        minrun = CalculateMinrun();
        runs = SplittingAnArray();
        List<List<int>> replateRuns = ResizeByMinrun();
        runs = InsertionSort(replateRuns);


        return UnionByMin();
    }

    private int CalculateMinrun()
    {
        int length = sortableArray.Count;

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

    private List<List<int>> SplittingAnArray()
    {
        List<List<int>> runs = new List<List<int>>();
        SortingMode currentSortMode = SortingMode.UNCLEAR;
        int currentRunStart = 0;
        int currentElementIndex = 1;
        int currentRunIndex = 0;
        List<int> run = new List<int>();

        for (int i = 0; i < sortableArray.Count; i++)
        {
            int element = sortableArray[i];
            
            if (i == currentRunStart)
            {
                run.Add(element);
                
                if (i == sortableArray.Count - 1)
                {
                    runs.Add(run);
                }
                
                continue;
            }

            if (i == currentRunStart + 1)
            {
                currentSortMode = GetSortingModeBy(sortableArray, currentRunStart, i);
                run.Add(element);
                
                if (i == sortableArray.Count - 1)
                {
                    runs.Add(run);
                }
                
                continue;
            }

            if (currentSortMode == SortingMode.INCREASING)
            {
                if (sortableArray[i - 1] <= sortableArray[i])
                {
                    run.Add(element);
                }
                else
                {
                    runs.Add(run);
                    run = new List<int>();
                    currentRunStart = i;
                    i = i - 1;
                    currentRunIndex = currentRunIndex + 1;
                }
            }
            else if (currentSortMode == SortingMode.DECREASING)
            {
                if (sortableArray[i - 1]  > sortableArray[i])
                {
                    run.Add(element);
                }
                else
                {
                    run.Reverse();
                    runs.Add(run);
                    run = new List<int>();
                    currentRunStart = i;
                    i = i - 1;
                    currentRunIndex = currentRunIndex + 1;
                }
            }

            if (i == sortableArray.Count - 1)
            {
                runs.Add(run);
            }
        }

        return runs;
    }

    private SortingMode GetSortingModeBy(List<int> array, int firstIndex, int secondIndex)
    {
        return array[firstIndex] > array[secondIndex] ? SortingMode.DECREASING : SortingMode.INCREASING;
    }

    private List<List<int>> ResizeByMinrun()
    {
        List<List<int>> replateRuns = runs.ToList();

        int indexCurrentRun = 0;
        List<int> currentRun = replateRuns[indexCurrentRun];
        List<int> nextRun = replateRuns[indexCurrentRun + 1];

        while (true)
        {
            if (indexCurrentRun + 1 >= replateRuns.Count)
            {
                break;
            }

            if (currentRun.Count >= minrun)
            {
                indexCurrentRun = indexCurrentRun + 1;
                
                currentRun = replateRuns[indexCurrentRun];
            }

            nextRun = replateRuns[indexCurrentRun + 1];

            int missingDimension = minrun - currentRun.Count;

            if (missingDimension >= nextRun.Count)
            {
                currentRun.AddRange(nextRun);
                replateRuns.Remove(nextRun);
            }
            else
            {
                currentRun.AddRange(nextRun.GetRange(0, missingDimension));
            }
        }

        return replateRuns;
    }

    private List<List<int>> InsertionSort(List<List<int>> replateRuns)
    {
        return replateRuns.ConvertAll(rr =>
            new List<int>(new InsertionSorter(rr.ToArray()).Sort()));
    }

    private int[] UnionByMin()
    {
        List<int> sortList = new List<int>();
        List<int> owner = null;
        int currentMin = 0;
        bool isFind = false;

        while (true)
        {
            for (int rcount = 0; rcount < runs.Count; rcount++)
            {
                List<int> potentialOwner = runs[rcount];
                
                if (potentialOwner.Count <= 0) continue;
                if (!isFind)
                {
                    currentMin = potentialOwner[0];
                    owner = potentialOwner;
                    isFind = true;
                    continue;
                }

                int potentialMin = potentialOwner[0];
                if (currentMin <= potentialMin) continue;
                currentMin = potentialMin;
                owner = potentialOwner;
            }

            if (isFind)
            {
                sortList.Add(owner[0]);
                owner.RemoveAt(0);
                isFind = false;
                owner = null;
            }
            else
            {
                break;
            }
        }

        return sortList.ToArray();
    }

    private enum SortingMode
    {
        UNCLEAR,
        INCREASING,
        DECREASING
    }
}