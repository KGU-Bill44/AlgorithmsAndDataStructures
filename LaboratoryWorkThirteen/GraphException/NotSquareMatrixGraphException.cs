namespace LaboratoryWorkThirteen.GraphException;

public class NotSquareMatrixGraphException : GraphException
{
    public NotSquareMatrixGraphException() : base("Матрица графа не квадратная")
    {
    }
}