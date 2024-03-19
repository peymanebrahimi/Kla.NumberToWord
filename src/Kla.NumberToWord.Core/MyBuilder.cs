using Kla.NumberToWord.Core.Domain;

namespace Kla.NumberToWord.Core;

public class MyBuilder
{
    private IWordProvider _wordProvider;
    private IProcessDigitToWord _fractionPartProcessor;
    private IProcessDigitToWord _wholePartProcessor;
    
    public MyBuilder For(IWordProvider wordProvider)
    {
        _wordProvider = wordProvider;
        return this;
    }

    public MyBuilder UsingFractionPart(IProcessDigitToWord processDigitToWord)
    {
        _fractionPartProcessor = processDigitToWord;
        return this;
    }
    
    public MyBuilder UsingWholePart(IProcessDigitToWord processDigitToWord)
    {
        _wholePartProcessor = processDigitToWord;
        return this;
    }
}