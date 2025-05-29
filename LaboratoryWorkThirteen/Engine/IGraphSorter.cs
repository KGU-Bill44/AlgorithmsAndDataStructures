namespace LaboratoryWorkThirteen.Engine;

public interface IGraphSorter
{
    /// <summary>
    /// Сортировка графа выбранном алгоритмом 
    /// </summary>
    /// <returns>Отсортированный граф</returns>
    public List<GraphNode> Sort();

    /// <summary>
    /// Уровни, которые прошли вершины при сортировке
    /// </summary>
    public IDictionary<int, IEnumerable<GraphNode>> NodesDistributedByLevels { get; }
}