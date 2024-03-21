using System.Text;
using Kla.NumberToWord.Core.Data;

namespace Kla.NumberToWord.Core.Domain;

internal class WholePartParser:FigureParser, IProcessDigitToWord
{
    private readonly DividerOption _dividerOption;
    public WholePartParser(IWordProvider wordProvider, DividerOption dividerOption)
    :base(wordProvider)
    {
        _dividerOption = dividerOption;
    }

    public string Process(string dollarPart)
    {
        if (IsZeroDollars(dollarPart))
        {
            return "zero";
        }
        
        var wholeNumberArray = dollarPart.Split(_dividerOption.ThousandSeparator);

        var topMostPartNumber = wholeNumberArray.Length;
        
        var sb = new StringBuilder();
        foreach (var item in wholeNumberArray)
        {
            sb.Append(GetWordOfOnePart(item));
            sb.Append(" ");
            sb.Append(_units[topMostPartNumber]);
            sb.Append(" ");
            topMostPartNumber--;
        }

        return sb.ToString().Trim();
    }

    private string GetWordOfOnePart(string part)
    {
        var firstPart = int.Parse(part);
        //get the hundred section of number
        var hundredsPlace = GetTheHundredsPlace(firstPart);
        var modulusOf100 = ModulusOf(firstPart, 100);
        var tensAndOnesPlace = GetTensAndOnesPlace(modulusOf100);

        return $"{hundredsPlace} {tensAndOnesPlace}".Trim();
    }
    
    private bool IsZeroDollars(string dollarPart)
    {
        var wholeNumber = dollarPart.Replace(" ", "");
        int.TryParse(wholeNumber, out var result);
        if (result == 0)
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
}