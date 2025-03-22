using System.Numerics;

namespace LaboratoryWorkNine;

public class TreeImplController<T> where T : IAdditionOperators<T, T, T>
{
    private TreeImplSum<T> activeThee;

    public void CreateTree()
    {
        activeThee = new TreeImplSum<T>();
    }

    public string GetContentString()
    {
        ThrowIfEmptyTree();
        return activeThee.ToString();
    }

    private void ThrowIfEmptyTree()
    {
        if (activeThee == null)
        {
            throw new TreeNullException();
        }
    }

    public void SetContent(T content, TreeBranch setNode, TreeBranch[] path)
    {
        ThrowIfEmptyTree();
        activeThee.SetDataToPath(content, setNode, path);
    }

    public void DeleteNode(TreeBranch[] path)
    {
        ThrowIfEmptyTree();
        activeThee.DeleteNode(path);
    }

    public string GetUnbalancedData()
    {
        ThrowIfEmptyTree();
        List<TreeImpl<T>> list = new List<TreeImpl<T>>();
        activeThee.FillUnbalancedNodes(list);
        return string.Join(", ", list.ConvertAll(l => l.Data));
    }

    public T GetSum()
    {
        return activeThee.SumData();
    }

    public void Swap()
    {
        ThrowIfEmptyTree();
        activeThee.SwapTree();
    }
}