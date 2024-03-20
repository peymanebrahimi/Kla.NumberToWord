using System.Text;
using Kla.NumberToWord.Core.Data;
using Kla.NumberToWord.Core.Domain;

namespace Kla.NumberToWord.Core;

internal class NumberToWordConvertor
{
    private readonly string _input;
    private readonly WordStore _wordStore;
    private readonly DividerOption _dividerOption;

    private string _centPart;
    private string _dollarPart;

    public NumberToWordConvertor(string input) : this(input, new WordStore(), new DividerOption())
    {
    }

    public NumberToWordConvertor(string input, WordStore wordStore, DividerOption dividerOption)
    {
        _input = input.Trim();
        _wordStore = wordStore;
        _dividerOption = dividerOption;
    }

    public string Convert()
    {
        Divide();

        //if (IsZero(_dollarPart) && string.IsNullOrEmpty(_centPart))
        //{
        //    return "zero";
        //}

        var centWord = ProcessCentToWord();
        var dollarWord = ProcessDollarToWord();

        return ConcatTwoParts(centWord, dollarWord);
    }

    private string ConcatTwoParts(string centWord, string dollarWord)
    {
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

        Validate();
    }

    private string ProcessCentToWord()
    {
        var centPartParser = new FractionalPartParser(_wordStore);

        return centPartParser.Process(_centPart);
    }

    private string ProcessDollarToWord()
    {
        if (IsZeroDollars())
        {
            return "zero";
        }

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

    private bool IsZero(string text)
    {
        var t = int.TryParse(text, out var result);
        if (t && result == 0)
        {
            return true;
        }

        return false;
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

    private bool IsZeroDollars()
    {
        var wholeNumber = _dollarPart.Replace(" ", "");
        int.TryParse(wholeNumber, out var result);
        if (result == 0)
        {
            return true;
        }

        return false;
    }
    private void Validate()
    {
        if (_centPart.Length > 2)
        {
            throw new ConversionException("Cent part length is not acceptable.");
        }

        if (_dollarPart.Length > 11)
        {
            throw new ConversionException("Dollar part length is not acceptable.");
        }

        var arr = _dollarPart.Split(_dividerOption.ThousandSeparator);
        foreach (var part in arr)
        {
            if (part.Length > 3)
            {
                throw new ConversionException("Each part of dollar section cannot be greater than 3 characters");
            }
        }

        var justDollarNumber = _dollarPart.Replace(_dividerOption.ThousandSeparator.ToString(), "");
        if (justDollarNumber.ToString().Length > 9)
        {
            throw new ConversionException("Number of figures provided for Dollar part is not acceptable.");
        }
    }
}