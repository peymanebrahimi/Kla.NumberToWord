using FluentAssertions;

namespace Kla.NumberToWord.Core.UnitTests;
[Collection(nameof(MyWordStoreFixture))]
public class NumberToWordConvertorUnitTest
{
    private readonly MyWordStoreFixture _fixture;
    private NumberToWordConvertor _parser;
    public NumberToWordConvertorUnitTest(MyWordStoreFixture fixture)
    {
        _fixture = fixture;
        _parser = new NumberToWordConvertor();
    }

    [Fact]
    public void Test1()
    {
        _parser.Convert("200").Should().Be("two hundred dollars");
    }
    [Fact]
    public void Test10()
    {
        _parser.Convert("200,1").Should().Be("two hundred dollars and ten cents");
    }
    [Fact]
    public void Test11()
    {
        _parser.Convert("1 200,01").Should().Be("one thousand two hundred dollars and one cent");
    }
    [Fact]
    public void Test12()
    {
        _parser.Convert("45 202,02").Should().Be("forty-five thousand two hundred two dollars and two cents");
    }
    [Fact]
    public void Test13()
    {
        _parser.Convert("3 005 202,02").Should().Be("three million five thousand two hundred two dollars and two cents");
    }
    [Fact]
    public void Test14()
    {
        _parser.Convert("0,02").Should().Be("zero dollars and two cents");
    }
    [Fact]
    public void Test15()
    {
        _parser.Convert("1").Should().Be("one dollar");
    }
    [Fact]
    public void Test16()
    {
        _parser.Convert("1").Should().Be("one dollar");
    }
    [Fact]
    public void Test17()
    {
        _parser.Convert("503,65").Should().Be("five hundred three dollars and sixty-five cents");
    }
}
