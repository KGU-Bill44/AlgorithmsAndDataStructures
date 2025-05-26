namespace LaboratoryWorkThirteen.Engine;

public interface IDemukronSorter
{
    /// <summary>
    /// Сортировка графа алгоритмом Демукрона
    /// </summary>
    /// <returns>Отсортированный граф</returns>
    public List<GraphNode> Sort();

    /// <summary>
    /// Уровни, которые прошли вершины при сортировке
    /// </summary>
    public IDictionary<int, IEnumerable<GraphNode>> NodesDistributedByLevels { get; }
}