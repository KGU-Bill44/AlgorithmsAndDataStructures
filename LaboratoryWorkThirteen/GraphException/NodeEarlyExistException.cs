namespace LaboratoryWorkThirteen.GraphException;

public class NodeEarlyExistException(int number) : GraphException($"Нода с номером {number} уже существует.")
{
}