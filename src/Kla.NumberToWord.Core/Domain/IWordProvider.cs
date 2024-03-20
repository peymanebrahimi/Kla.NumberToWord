namespace Kla.NumberToWord.Core.Domain;

public interface IWordProvider
{
    string? GetWordOfNumber(int number);
}