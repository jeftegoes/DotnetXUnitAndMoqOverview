using System.Collections.Generic;
using ExampleSproutMethodTechnique;
using Xunit;

namespace ExampleSproutTechnique.Tests.Tests;

public class LegacyClassTests
{
    [Fact]
    public void GetValidItems_GivenTwoDictionaries_ReturnsUncommon()
    {
        var legacyClass = new LegacyClass();

        var dict1 = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 } };
        var dict2 = new Dictionary<int, int>() { { 7, 0 }, { 8, 0 }, { 9, 0 }, { 1, 800 } };
        var validItems = legacyClass.GetValidItems<int, int>(dict1, dict2);
        var expectedResult = new Dictionary<int, int> { { 2, 0 }, { 3, 0 } };

        Assert.Equal(validItems, expectedResult);
    }
}