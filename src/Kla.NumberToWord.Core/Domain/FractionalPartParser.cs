namespace Kla.NumberToWord.Core.Domain;

internal class FractionalPartParser : FigureParser, IProcessDigitToWord
{
    public FractionalPartParser(IWordProvider wordProvider)
        : base(wordProvider)
    {
    }

    public string Process(string cent)
    {
        cent = cent.PadRight(2, '0');
        var number = int.Parse(cent);
        if (number == 0)
        {
            return string.Empty;
        }

        var result = GetTensAndOnesPlace(number);// _wordProvider.GetWordOfNumber(number);

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