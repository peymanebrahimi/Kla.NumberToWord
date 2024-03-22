using System.Text;
using Kla.NumberToWord.Core.Data;
using Kla.NumberToWord.Core.Domain;

namespace Kla.NumberToWord.Core;

public class NumberToWordConvertor: INumberToWordConvertor
{
    private string _input;
    private readonly IWordProvider _wordProvider;
    private readonly DividerOption _dividerOption;

    private string _centPart;
    private string _dollarPart;

    public NumberToWordConvertor() : this(new WordStore(), new DividerOption())
    {
    }

    public NumberToWordConvertor(IWordProvider wordProvider, DividerOption dividerOption)
    {

        _wordProvider = wordProvider;
        _dividerOption = dividerOption;
    }

    public string Convert(string input)
    {
        _input = input.Trim();

        Divide();

        Validate();
        
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
    }

    private string ProcessCentToWord()
    {
        var centPartParser = new FractionalPartParser(_wordProvider);

        return centPartParser.Process(_centPart);
    }

    private string ProcessDollarToWord()
    {
        var x = new WholePartParser(_wordProvider, _dividerOption);

        return x.Process(_dollarPart);
    }

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