using FluentAssertions;

namespace Kla.NumberToWord.Core.UnitTests;

[Collection(nameof(MyWordStoreFixture))]
public class FirstPartOfWholeNumberUnitTest
{
    private readonly ThreeFigurePartParser _parser;

    public FirstPartOfWholeNumberUnitTest(MyWordStoreFixture fixture)
    {
        _parser = new ThreeFigurePartParser(fixture.WordStore);
    }

    // could not achieve by inlineData and theory
    [Fact]
    public void Test1()
    {
        _parser.GetWordOfOnePart("200").Should().Be("two hundred");
        _parser.GetWordOfOnePart("253").Should().Be("two hundred fifty-three");
        _parser.GetWordOfOnePart("210").Should().Be("two hundred ten");
        _parser.GetWordOfOnePart("201").Should().Be("two hundred one");
        _parser.GetWordOfOnePart("012").Should().Be("twelve");
        _parser.GetWordOfOnePart("57").Should().Be("fifty-seven");
        _parser.GetWordOfOnePart("13").Should().Be("thirteen");
        _parser.GetWordOfOnePart("3").Should().Be("three");
        _parser.GetWordOfOnePart("001").Should().Be("one");
        _parser.GetWordOfOnePart("010").Should().Be("ten");
        _parser.GetWordOfOnePart("100").Should().Be("one hundred");
        _parser.GetWordOfOnePart("01").Should().Be("one");
        _parser.GetWordOfOnePart("10").Should().Be("ten");
        _parser.GetWordOfOnePart("101").Should().Be("one hundred one");
        _parser.GetWordOfOnePart("011").Should().Be("eleven");
        _parser.GetWordOfOnePart("110").Should().Be("one hundred ten");
        _parser.GetWordOfOnePart("111").Should().Be("one hundred eleven");
        _parser.GetWordOfOnePart("1").Should().Be("one");
    }
}