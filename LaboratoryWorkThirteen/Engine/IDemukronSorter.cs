namespace LaboratoryWorkThirteen.Engine;

public interface IDemukronSorter
{
    public List<GraphNode> Sort();
    public IDictionary<int, IEnumerable<GraphNode>> NodesDistributedByLevels { get; }
}