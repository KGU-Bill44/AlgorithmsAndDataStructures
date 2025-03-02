using System.Text;

namespace LaboratoryWorkSix;

public class GroupedDeque<T>
{
    private DequeImpl<T> singleDigitNumbers;
    private DequeImpl<T> twoDigitNumbers;
    private DequeImpl<T> remainingNumbers;

    public GroupedDeque(DequeImpl<T> singleDigitNumbers, DequeImpl<T> twoDigitNumbers, DequeImpl<T> remainingNumbers)
    {
        this.singleDigitNumbers = singleDigitNumbers;
        this.twoDigitNumbers = twoDigitNumbers;
        this.remainingNumbers = remainingNumbers;
    }

    public DequeImpl<T> SingleDigitNumbers => singleDigitNumbers;

    public DequeImpl<T> TwoDigitNumbers => twoDigitNumbers;

    public DequeImpl<T> RemainingNumbers => remainingNumbers;

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder(string.Join(", ", singleDigitNumbers))
            .Append(" - однозначные числа\n")
            .Append(string.Join(", ", twoDigitNumbers))
            .Append(" - двухзначные числа\n")
            .Append(string.Join(", ", remainingNumbers))
            .Append(" - неотсортированные числа");

        return stringBuilder.ToString();
    }
}