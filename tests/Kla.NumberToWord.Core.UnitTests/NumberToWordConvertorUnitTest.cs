﻿using FluentAssertions;

namespace Kla.NumberToWord.Core.UnitTests;
[Collection(nameof(MyWordStoreFixture))]
public class NumberToWordConvertorUnitTest
{
    private readonly MyWordStoreFixture _fixture;

    public NumberToWordConvertorUnitTest(MyWordStoreFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test1()
    {
        var parser = new NumberToWordConvertor("200");
        parser.Process().Should().Be("two hundred dollars");
    }
    [Fact]
    public void Test10()
    {
        var parser = new NumberToWordConvertor("200,1");
        parser.Process().Should().Be("two hundred dollars and ten cents");
    }
    [Fact]
    public void Test11()
    {
        var parser = new NumberToWordConvertor("1 200,01");
        parser.Process().Should().Be("one thousand two hundred dollars and one cent");
    }
    [Fact]
    public void Test12()
    {
        var parser = new NumberToWordConvertor("45 202,02");
        parser.Process().Should().Be("forty-five thousand two hundred two dollars and two cents");
    }
    [Fact]
    public void Test13()
    {
        var parser = new NumberToWordConvertor("3 005 202,02");
        parser.Process().Should().Be("three million five thousand two hundred two dollars and two cents");
    }
}