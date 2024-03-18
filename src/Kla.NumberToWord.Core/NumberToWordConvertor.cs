using System.Text;

namespace Kla.NumberToWord.Core;

internal class NumberToWordConvertor
{
    private readonly string _input;
    //private readonly WordStore _wordStore;
    private readonly DividerOption _dividerOption;
    private string _centPart;
    private string _dollarPart;

    public NumberToWordConvertor(string input) : this(input, new WordStore(), new DividerOption())
    {

    }
    public NumberToWordConvertor(string input, WordStore wordStore, DividerOption dividerOption)
    {
        _input = input;
        _wordStore = wordStore;
        _dividerOption = dividerOption;
    }

    public string Process()
    {
        if (IsZero())
        {
            return "zero";
        }

        Divide();
        var centWord = ProcessCentToWord();
        var dollarWord = ProcessDollarToWord();

        string dollar = "dollars";
        if (IsOneDollar())
        {
            dollar = "dollar";
        }

        var nad = string.Empty;
        if (!string.IsNullOrEmpty(centWord))
        {
            nad = " and ";
        }

        var sb = new StringBuilder();
        sb.Append(dollarWord);
        sb.Append(" ");
        sb.Append(dollar);
        sb.Append(nad);
        sb.Append(centWord);
        
        return sb.ToString().Trim();
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

    private void Divide()
    {
        var decimalSeparatorIndex = _input.IndexOf(_dividerOption.DecimalSeparator);
        if (decimalSeparatorIndex == -1)
        {
            _centPart = string.Empty;
            _dollarPart = _input;
        }
        else
        {
            _centPart = _input.Substring(decimalSeparatorIndex + 1);
            _dollarPart = _input.Substring(0, decimalSeparatorIndex);
        }

    }

    private string ProcessCentToWord()
    {
        var centPartParser = new CentPartParser(_wordStore);

        return centPartParser.GetWordOfCentPart(_centPart);
    }
    private string ProcessDollarToWord()
    {
        var wholeNumberArray = _dollarPart.Split(_dividerOption.ThousandSeparator);

        var topMostPartNumber = wholeNumberArray.Length;
        var threeFigurePartParser = new ThreeFigurePartParser(_wordStore);
        var sb = new StringBuilder();
        foreach (var item in wholeNumberArray)
        {
            sb.Append(threeFigurePartParser.GetWordOfOnePart(item));
            sb.Append(" ");
            sb.Append(_units[topMostPartNumber]);
            sb.Append(" ");
            topMostPartNumber--;
        }

        return sb.ToString().Trim();
    }
    private readonly Dictionary<int, string> _units = new()
    {
        {1, ""},
        {2, "thousand"},
        {3, "million"},
    };

    private bool IsOneDollar()
    {
        var wholeNumber = _dollarPart.Replace(" ", "");
        int.TryParse(wholeNumber, out var result);
        if (result == 1)
        {
            return true;
        }
        return false;
    }
}