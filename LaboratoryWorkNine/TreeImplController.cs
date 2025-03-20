namespace LaboratoryWorkNine;

public class TreeImplController<T>
{
    private TreeImpl<T> activeThee;

    public void CreateTree()
    {
        activeThee = new TreeImpl<T>();
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
}