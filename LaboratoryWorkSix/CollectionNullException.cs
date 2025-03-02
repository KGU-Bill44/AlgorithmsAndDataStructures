namespace LaboratoryWorkSix;

public class CollectionNullException : Exception
{
    public CollectionNullException() : base("Коллекции не сущесвует")
    {
    }
}