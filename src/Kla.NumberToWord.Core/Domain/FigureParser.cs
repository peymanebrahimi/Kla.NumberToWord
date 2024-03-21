using Kla.NumberToWord.Core.Data;

namespace Kla.NumberToWord.Core.Domain;

internal class FigureParser
{
    private readonly IWordProvider _wordProvider;

    public FigureParser(IWordProvider wordProvider)
    {
        _wordProvider = wordProvider;
    }

    
    protected string GetTheHundredsPlace(int number)
    {
        var divideBy100 = DivideBy(number, 100);
        if (divideBy100 == 0)
        {
            return string.Empty;
        }

        return $"{_wordProvider.GetWordOfNumber(divideBy100)} hundred".Trim();
    }
    protected string GetTensAndOnesPlace(int number)
    {
        var tensPlaceWord = _wordProvider.GetWordOfNumber(number);
        if (tensPlaceWord is null)
        {
            var divideBy10 = DivideBy(number, 10);
            var twoFigure = divideBy10.ToString().PadRight(2, '0');
            int.TryParse(twoFigure, out var twoFigureNumber);
            var tens = _wordProvider.GetWordOfNumber(twoFigureNumber);
            var modulusOf10 = ModulusOf(number, 10);
            var ones = _wordProvider.GetWordOfNumber(modulusOf10);
            return $"{tens}-{ones}";
        }

        if (tensPlaceWord == "zero")
        {
            return string.Empty;
        }

        return tensPlaceWord;
    }
    protected int DivideBy(int value, int by)
    {
        return value / by;
    }
    protected int ModulusOf(int value, int of)
    {
        return value % of;
    }
}