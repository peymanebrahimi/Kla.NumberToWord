namespace Kla.NumberToWord.Core;

internal class CentPartParser
{
    private readonly WordStore _wordStore;

    public CentPartParser(WordStore wordStore)
    {
        _wordStore = wordStore;
    }

    public string GetWordOfCentPart(string cent)
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