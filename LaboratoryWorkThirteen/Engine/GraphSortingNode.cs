namespace LaboratoryWorkThirteen.Engine;

public class GraphSortingNode
{
    private GraphNode origin;
    private int degIn;
    private List<GraphSortingNode> degOuts;
        
    public GraphSortingNode(GraphNode origin)
    {
        this.origin = origin;
        this.degIn = origin.DegIn;
    }

    public GraphNode Origin => origin;
    public int DegIn => degIn;

    public override bool Equals(object? obj)
    {
        if (obj is GraphSortingNode node)
        {
            return Origin.Equals(node.Origin);
        }

        return false;
    }

    public void EraseArc()
    {
        degOuts.ForEach(dov => dov.degIn -= 1);
    }
}