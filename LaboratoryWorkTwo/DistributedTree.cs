namespace LaboratoryWorkTwo;

public class DistributedTree
{
    private List<int> runArray;
    
    private DistributedTree left;
    private DistributedTree right;

    public List<int> RunArray => runArray;

    public DistributedTree()
    {
    }

    private DistributedTree(List<int> runArray)
    {
        this.runArray = runArray;
    }

    public void Add(int[] value)
    {
        List<int> valueAsList = new List<int>(value);
        if (left != null && right != null)
        {
            DistributedTree addedBranch = left.GetDeep() > right.GetDeep() ? right : left;
            addedBranch.Add(value);
        }
        else if (runArray == null)
        {
            runArray = valueAsList;
        }
        else
        {
            SetTree(runArray, valueAsList);
        }
    }

    private int GetDeep()
    {
        if (runArray != null) return 1;
        
        return left.GetDeep() + right.GetDeep();
    }

    private void SetTree(List<int> forLeft, List<int> forRight)
    {
        left = new DistributedTree(forLeft);
        right = new DistributedTree(forRight);
        runArray = null;
    }

    public int[] UnionByMin()
    {
        List<int> allRun = new List<int>();
        Pointer pointer = new Pointer();
        
        while (true)
        {
            if (TryFindMin(pointer))
            {
                allRun.Add(pointer.Min);
            }
            else
            {
                break;
            }
        }

        return allRun.ToArray();
    }

    private bool TryFindMin(Pointer pointer)
    {
        SearchMin(pointer);
        return pointer.IsFind;
    }

    private void SearchMin(Pointer pointer)
    {
        if (runArray != null)
        {
            pointer.SetPotentialMinimum(this);
        }
        else
        {
            left.SearchMin(pointer);
            right.SearchMin(pointer);
        }
    }

    public int UseMin()
    {
        int min = this.runArray[0];
        this.runArray.RemoveAt(0);
        return min;
    }
}