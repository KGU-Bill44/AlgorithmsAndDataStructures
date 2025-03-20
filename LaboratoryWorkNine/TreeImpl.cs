using System.Text;

namespace LaboratoryWorkNine;

public class TreeImpl<T>
{
    private T data;
    private TreeImpl<T> right;
    private TreeImpl<T> left;

    public TreeImpl()
    {
    }

    public TreeImpl(T data)
    {
        this.data = data;
    }

    public T Data
    {
        get => data;
        set => data = value;
    }

    public TreeImpl<T> Right => right;

    public TreeImpl<T> Left => left;

    public void SetDataToPath(T item, TreeBranch setOn, params TreeBranch[] path)
    {
        TreeImpl<T> branchByPath = GetBranchByPath(path);

        switch (setOn)
        {
            case TreeBranch.Left:
                branchByPath.SetDataOnLeft(item);
                break;
            case TreeBranch.Right:
                branchByPath.SetDataOnRight(item);
                break;
        }
    }

    public T GetDataByPath(TreeBranch[] path)
    {
        return GetBranchByPath(path).Data;
    }

    private TreeImpl<T> GetBranchByPath(TreeBranch[] path)
    {
        int indexStep = 0;
        TreeImpl<T> stepBranch = this;
        foreach (var step in path)
        {
            stepBranch = step switch
            {
                TreeBranch.Left => stepBranch.left,
                TreeBranch.Right => stepBranch.right,
                _ => throw new ArgumentOutOfRangeException()
            };

            if (stepBranch == null)
            {
                throw new StepBranchNotExist(path, indexStep);
            }

            indexStep = indexStep + 1;
        }

        return stepBranch;
    }

    public void SetDataOnRight(T item)
    {
        SetData(ref right, item);
    }

    public void SetDataOnLeft(T item)
    {
        SetData(ref left, item);
    }

    private void SetData(ref TreeImpl<T> treeImpl, T item)
    {
        if (treeImpl != null)
        {
            throw new BranchExistsException();
        }

        treeImpl = new TreeImpl<T>(item);
    }

    public void SwapTree()
    {
        if (left != null)
        {
            left.SwapTree();
        }

        if (right != null)
        {
            right.SwapTree();
        }

        (right, left) = (left, right);
    }

    public override string ToString()
    {
        StringBuilder strings = new StringBuilder();
        return ToString(strings).ToString();
    }

    private StringBuilder ToString(StringBuilder strings, int size = 0)
    {
        for (int i = 0; i < size; i++)
        {
            strings.Append('\t');
        }

        strings.Append(data).Append('\n');
        left?.ToString(strings, size + 1);
        right?.ToString(strings, size + 1);

        return strings;
    }

    public void DeleteNode(params TreeBranch[] path)
    {
        if (path.Length == 0)
        {
            Clear();
        }

        TreeBranch lastElement = path[^1];
        TreeImpl<T> treeNode = GetBranchByPath(path[..^2]);
        treeNode.Delete(lastElement);
    }

    public void Delete(TreeBranch lastElement)
    {
        switch (lastElement)
        {
            case TreeBranch.Left:
                left = default;
                break;
            
            case TreeBranch.Right:
                right = default;
                break;
        }
    }

    private void Clear()
    {
        left = right = default;
        data = default;
    }
}