namespace Kla.NumberToWord.Core;

public class ConversionException : Exception
{
    public ConversionException(string message)
        : base(message)
    {
    }
}