using System.Text;

namespace Kla.NumberToWord.Core;

internal class FractionalPartParser: IProcessDigitToWord
{
    private readonly WordStore _wordStore;

    public FractionalPartParser(WordStore wordStore)
    {
        _wordStore = wordStore;
    }

    public string Process(string cent)
    {
        cent = cent.PadRight(2, '0');
        var number = int.Parse(cent);
        if (number==0)
        {
            return string.Empty;
        }
        var result = _wordStore.GetWordOfNumber(number);
        
        return $"{result} {GetCentPhrase(number)}".Trim();
    }

    private string GetCentPhrase(int number)
    {
        return number switch
        {
            0 => string.Empty,
            1 => "cent",
            _ => "cents"
        };
    }
}

public interface IProcessDigitToWord
{
    string Process(string text);
}

internal class WholePartParser: IProcessDigitToWord
{
    private readonly WordStore _wordStore;

    public WholePartParser(WordStore wordStore)
    {
        _wordStore = wordStore;
    }

    public string Process(string dollarPart)
    {
        var wholeNumberArray = dollarPart.Split(_dividerOption.ThousandSeparator);

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
}