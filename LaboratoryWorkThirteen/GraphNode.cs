namespace LaboratoryWorkThirteen;

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
    public List<GraphNode> DegOut => degOut;

    public int DegIn
    {
        get => degIn;
        set => degIn = value;
    }
}