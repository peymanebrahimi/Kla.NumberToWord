using FluentAssertions;

namespace Kla.NumberToWord.Core.UnitTests;

[Collection(nameof(MyWordStoreFixture))]
public class CentPartOfNumberUnitTests
{
    private readonly FractionalPartParser _parser;

    public CentPartOfNumberUnitTests(MyWordStoreFixture fixture)
    {
        _parser = new FractionalPartParser(fixture.WordStore);
    }

    [Fact]
    public void Test1()
    {
        _parser.Process("01").Should().Be("one cent");
        _parser.Process("10").Should().Be("ten cents");
        _parser.Process("11").Should().Be("eleven cents");
        _parser.Process("1").Should().Be("ten cents");
        _parser.Process("13").Should().Be("thirteen cents");
    }
}