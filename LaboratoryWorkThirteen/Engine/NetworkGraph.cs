using System.Collections.ObjectModel;
using LaboratoryWorkThirteen.GraphException;

namespace LaboratoryWorkThirteen.Engine;

public class NetworkGraph
{
    private List<GraphNode> nodes;

    public NetworkGraph()
    {
        nodes = new List<GraphNode>();
    }

    public virtual void AddNode(GraphNode node)
    {
        if (nodes.Any(n => n.Number == node.Number))
        {
            throw new NodeEarlyExistException(node.Number);
        }

        nodes.Add(node);
    }

    public virtual void AddEdge(GraphNode source, GraphNode target)
    {
        if (!nodes.Contains(source) || !nodes.Contains(target))
        {
            throw new NodeNotFound();
        }

        source.AddNode(target);
    }

    public virtual void RemoveNode(GraphNode node)
    {
        if (!nodes.Contains(node))
        {
            return;
        }
        
        foreach (var otherNode in nodes)
        {
            otherNode.RemoveNode(node);
        }

        nodes.Remove(node);
    }

    public virtual void RemoveEdge(GraphNode source, GraphNode target)
    {
        if (!nodes.Contains(source) || !nodes.Contains(target))
        {
            throw new NodeNotFound();
        }

        source.RemoveNode(target);
    }

    public virtual IReadOnlyList<GraphNode> GetNodes()
    {
        return new ReadOnlyCollection<GraphNode>(nodes);
    }

    public virtual IEnumerable<GraphNode> GetNeighbors(GraphNode node)
    {
        return node.DegOut;
    }

    public GraphNode this[int index] => nodes[index];
}