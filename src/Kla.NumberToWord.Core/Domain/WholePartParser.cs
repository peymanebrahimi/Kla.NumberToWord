using System.Text;
using Kla.NumberToWord.Core.Data;

namespace Kla.NumberToWord.Core.Domain;

internal class WholePartParser: IProcessDigitToWord
{
    private readonly WordStore _wordStore;
    private readonly DividerOption _dividerOption;
    public WholePartParser(WordStore wordStore, DividerOption dividerOption)
    {
        _wordStore = wordStore;
        _dividerOption = dividerOption;
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