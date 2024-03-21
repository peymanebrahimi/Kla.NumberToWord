using FluentAssertions;
using Kla.NumberToWord.Core.Domain;

namespace Kla.NumberToWord.Core.UnitTests;

[Collection(nameof(MyWordStoreFixture))]
public class WholePartParserUnitTest
{
    private readonly WholePartParser _parser;

    public WholePartParserUnitTest(MyWordStoreFixture fixture)
    {
        _parser = new WholePartParser(fixture.WordProvider, fixture.DividerOption);
    }

    // could not achieve by inlineData and theory
    [Fact]
    public void Test1()
    {
        _parser.Process("200").Should().Be("two hundred");
        _parser.Process("253").Should().Be("two hundred fifty-three");
        _parser.Process("210").Should().Be("two hundred ten");
        _parser.Process("201").Should().Be("two hundred one");
        _parser.Process("012").Should().Be("twelve");
        _parser.Process("57").Should().Be("fifty-seven");
        _parser.Process("13").Should().Be("thirteen");
        _parser.Process("3").Should().Be("three");
        _parser.Process("001").Should().Be("one");
        _parser.Process("010").Should().Be("ten");
        _parser.Process("100").Should().Be("one hundred");
        _parser.Process("01").Should().Be("one");
        _parser.Process("10").Should().Be("ten");
        _parser.Process("101").Should().Be("one hundred one");
        _parser.Process("011").Should().Be("eleven");
        _parser.Process("110").Should().Be("one hundred ten");
        _parser.Process("111").Should().Be("one hundred eleven");
        _parser.Process("1").Should().Be("one");
    }
}