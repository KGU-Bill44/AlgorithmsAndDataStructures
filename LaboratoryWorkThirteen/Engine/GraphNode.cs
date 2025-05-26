using System.Collections.ObjectModel;

namespace LaboratoryWorkThirteen.Engine;

public class GraphNode
{
    private int number;
    private List<GraphNode> degOut;
    private int degIn;

    public GraphNode(int number) : this(number, new List<GraphNode>(), 0)
    {
    }

    public GraphNode(int number, List<GraphNode> degOut, int degIn)
    {
        this.number = number;
        this.degOut = degOut;
        this.degIn = degIn;
    }

    public int Number => number;
    public IReadOnlyList<GraphNode> DegOut => new ReadOnlyCollection<GraphNode>(degOut);
    public int DegIn => degIn;

    public void AddNode(GraphNode node)
    {
        degOut.Add(node);
        node.degIn++;
    }

    public void RemoveNode(GraphNode node)
    {
        if (degOut.Remove(node))
        {
            node.degIn--;
        }
    }

    public void Clear()
    {
        degOut.ForEach(ng => ng.degIn--);
    }
}