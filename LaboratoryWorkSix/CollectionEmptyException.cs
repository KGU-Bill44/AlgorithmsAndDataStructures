namespace LaboratoryWorkSix;

public class CollectionEmptyException : Exception
{
    public CollectionEmptyException() : base("Коллекция пуста")
    {
    }
}