namespace Kla.NumberToWord.Core;

public class NumberDivider
{
    private readonly string _input;

    private readonly DividerOption _dividerOption;
    private readonly WordStore _wordStore;

    public string CentPartWord { get; private set; }

    public NumberDivider(string input) : this(input, new WordStore(), new DividerOption())
    {
    }

    public NumberDivider(string input, WordStore wordStore, DividerOption dividerOption)
    {
        _input = input;
        _wordStore = wordStore;
        _dividerOption = dividerOption;
    }

    private bool IsZero()
    {
        int.TryParse(_input, out var z);
        if (z == 0)
        {
            return true;
        }

        return false;
    }
    public string Parser()
    {
        var decimalSeparatorIndex = _input.IndexOf(_dividerOption.DecimalSeparator);
        var centPartParser = new CentPartParser(_wordStore);

        if (decimalSeparatorIndex == -1)
        {
            CentPartWord = centPartParser.GetWordOfCentPart("0");
        }
        else
        {
            var cent = _input.Substring(decimalSeparatorIndex + 1);
            CentPartWord = centPartParser.GetWordOfCentPart(cent);
        }

        if (IsZero())
        {
            return "zero";
        }
        var y = _input.Split(_dividerOption.ThousandSeparator);
        string r = "";
        var threeFigurePartParser = new ThreeFigurePartParser(_wordStore);
        switch (y.Length)
        {
            case 1:
                r = threeFigurePartParser.GetWordOfOnePart(y[0]);
                return r;
                break;
            //case 2:
            //    //kilo
            //    break;
            //case 3:
            //    //mega
            //    break;
            default:
                return r;
                break;
        }
    }
}