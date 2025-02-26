namespace LaboratoryWorkFive;

public class EmptyControllerException : Exception
{
    public override string Message => "Ошибка: контроллер пустой.\n";
}