namespace Kla.NumberToWord.Core;

public class ThreeFigurePartParser
{
    private readonly WordStore _wordStore;

    public ThreeFigurePartParser(WordStore wordStore)
    {
        _wordStore = wordStore;
    }

    public string GetWordOfOnePart(string part)
    {
        var firstPart = int.Parse(part);
        //get the hundred section of number
        var hundredsPlace = GetTheHundredsPlace(firstPart);
        var modulusOf100 = ModulusOf(firstPart, 100);
        var tensAndOnesPlace = GetTensAndOnesPlace(modulusOf100);

        return $"{hundredsPlace} {tensAndOnesPlace}".Trim();
    }
    private string GetTheHundredsPlace(int number)
    {
        var divideBy100 = DivideBy(number, 100);
        if (divideBy100 == 0)
        {
            return string.Empty;
        }

        return $"{_wordStore.GetWordOfNumber(divideBy100)} hundred".Trim();
    }
    private string GetTensAndOnesPlace(int number)
    {
        var tensPlaceWord = _wordStore.GetWordOfNumber(number);
        if (tensPlaceWord is null)
        {
            var divideBy10 = DivideBy(number, 10);
            var twoFigure = divideBy10.ToString().PadRight(2, '0');
            int.TryParse(twoFigure, out var twoFigureNumber);
            var tens = _wordStore.GetWordOfNumber(twoFigureNumber);
            var modulusOf10 = ModulusOf(number, 10);
            var ones = _wordStore.GetWordOfNumber(modulusOf10);
            return $"{tens}-{ones}";
        }

        if (tensPlaceWord == "zero")
        {
            return string.Empty;
        }

        return tensPlaceWord;
    }
    private int DivideBy(int value, int by)
    {
        return value / by;
    }
    private int ModulusOf(int value, int of)
    {
        return value % of;
    }
}