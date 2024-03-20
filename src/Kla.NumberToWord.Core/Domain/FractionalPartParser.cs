using Kla.NumberToWord.Core.Data;

namespace Kla.NumberToWord.Core.Domain;

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