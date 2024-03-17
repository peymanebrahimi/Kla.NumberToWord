using FluentAssertions;

namespace Kla.NumberToWord.Core.UnitTests;

public class FirstPartOfWholeNumberUnitTest
{
    // could not achieve by inlineData and theory
    [Fact]
    public void Test1()
    {
        NumberDivider numberDivider = new NumberDivider("200");
        numberDivider.Parser().Should().Be("two hundred");
    }
    [Fact]
    public void Test2()
    {
        NumberDivider numberDivider = new NumberDivider("253");
        numberDivider.Parser().Should().Be("two hundred fifty-three");
    }
    [Fact]
    public void Test3()
    {
        NumberDivider numberDivider = new NumberDivider("210");
        numberDivider.Parser().Should().Be("two hundred ten");
    }
    [Fact]
    public void Test4()
    {
        NumberDivider numberDivider = new NumberDivider("201");
        numberDivider.Parser().Should().Be("two hundred one");
    }
    [Fact]
    public void Test5()
    {
        NumberDivider numberDivider = new NumberDivider("203");
        numberDivider.Parser().Should().Be("two hundred three");
    }
    [Fact]
    public void Test6()
    {
        NumberDivider numberDivider = new NumberDivider("012");
        numberDivider.Parser().Should().Be("twelve");
    }
    [Fact]
    public void Test7()
    {
        NumberDivider numberDivider = new NumberDivider("57");
        numberDivider.Parser().Should().Be("fifty-seven");
    }
    [Fact]
    public void Test8()
    {
        NumberDivider numberDivider = new NumberDivider("13");
        numberDivider.Parser().Should().Be("thirteen");
    }
    [Fact]
    public void Test9()
    {
        NumberDivider numberDivider = new NumberDivider("3");
        numberDivider.Parser().Should().Be("three");
    }
    [Fact]
    public void Test10()
    {
        NumberDivider numberDivider = new NumberDivider("001");
        numberDivider.Parser().Should().Be("one");
    }
    [Fact]
    public void Test11()
    {
        NumberDivider numberDivider = new NumberDivider("010");
        numberDivider.Parser().Should().Be("ten");
    }
    [Fact]
    public void Test12()
    {
        NumberDivider numberDivider = new NumberDivider("100");
        numberDivider.Parser().Should().Be("one hundred");
    }
    [Fact]
    public void Test13()
    {
        NumberDivider numberDivider = new NumberDivider("03");
        numberDivider.Parser().Should().Be("three");
    }
    [Fact]
    public void Test14()
    {
        NumberDivider numberDivider = new NumberDivider("0");
        numberDivider.Parser().Should().Be("zero");
    }
    [Fact]
    public void Test15()
    {
        NumberDivider numberDivider = new NumberDivider("00");
        numberDivider.Parser().Should().Be("");
    }
    [Fact]
    public void Test16()
    {
        NumberDivider numberDivider = new NumberDivider("000");
        numberDivider.Parser().Should().Be("");
    }
    [Fact]
    public void Test17()
    {
        NumberDivider numberDivider = new NumberDivider("10");
        numberDivider.Parser().Should().Be("ten");
    }
    [Fact]
    public void Test18()
    {
        NumberDivider numberDivider = new NumberDivider("01");
        numberDivider.Parser().Should().Be("one");
    }
    //[Fact]
    //public void Test19()
    //{
    //    NumberDivider divider = new NumberDivider("010");
    //    divider.Parser().Should().Be("ten");
    //}
    //[Fact]
    //public void Test20()
    //{
    //    NumberDivider divider = new NumberDivider("001");
    //    divider.Parser().Should().Be("one");
    //}
    //[Fact]
    //public void Test21()
    //{
    //    NumberDivider divider = new NumberDivider("100");
    //    divider.Parser().Should().Be("one hundred");
    //}
    [Fact]
    public void Test22()
    {
        NumberDivider numberDivider = new NumberDivider("101");
        numberDivider.Parser().Should().Be("one hundred one");
    }
    [Fact]
    public void Test23()
    {
        NumberDivider numberDivider = new NumberDivider("011");
        numberDivider.Parser().Should().Be("eleven");
    }
    [Fact]
    public void Test24()
    {
        NumberDivider numberDivider = new NumberDivider("110");
        numberDivider.Parser().Should().Be("one hundred ten");
    }
    [Fact]
    public void Test25()
    {
        NumberDivider numberDivider = new NumberDivider("111");
        numberDivider.Parser().Should().Be("one hundred eleven");
    }
    [Fact]
    public void Test26()
    {
        NumberDivider numberDivider = new NumberDivider("1");
        numberDivider.Parser().Should().Be("one");
    }
    
}