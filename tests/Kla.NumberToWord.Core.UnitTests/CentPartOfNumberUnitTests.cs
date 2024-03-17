using FluentAssertions;

namespace Kla.NumberToWord.Core.UnitTests;

[Collection(nameof(MyWordStoreFixture))]
public class CentPartOfNumberUnitTests
{
    private readonly CentPartParser _parser;

    public CentPartOfNumberUnitTests(MyWordStoreFixture fixture)
    {
        _parser = new CentPartParser(fixture.WordStore);
    }

    [Fact]
    public void Test1()
    {
        _parser.GetWordOfCentPart("01").Should().Be("one cent");
        _parser.GetWordOfCentPart("10").Should().Be("ten cents");
        _parser.GetWordOfCentPart("11").Should().Be("eleven cents");
        _parser.GetWordOfCentPart("1").Should().Be("ten cents");
        _parser.GetWordOfCentPart("13").Should().Be("thirteen cents");
    }
}