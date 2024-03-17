namespace Kla.NumberToWord.Core;

public class DividerOption
{
    public char ThousandSeparator { get; }
    public char DecimalSeparator { get; }

    public DividerOption(char thousandSeparator = ' ', char decimalSeparator = ',')
    {
        ThousandSeparator = thousandSeparator;
        DecimalSeparator = decimalSeparator;
    }
}