# xUnit.net overview <!-- omit in toc -->

## Contents <!-- omit in toc -->

- [1. What's is xUnit.net](#1-whats-is-xunitnet)
- [2. Features](#2-features)
- [3. Package dependencies](#3-package-dependencies)
- [4. Phases of unit testing](#4-phases-of-unit-testing)
  - [4.1. Arrange](#41-arrange)
  - [4.2. Act](#42-act)
  - [4.3. Assert](#43-assert)
- [5. Commons asserts](#5-commons-asserts)
  - [5.1. Any values](#51-any-values)
  - [5.2. Boolean](#52-boolean)
  - [5.3. Strings](#53-strings)
  - [5.4. Collections](#54-collections)
  - [5.5. Range values](#55-range-values)
  - [5.6. Assert each items of the collection match the condition](#56-assert-each-items-of-the-collection-match-the-condition)
  - [5.7. Assert the collection contains 3 items and the items match the conditions (in the declared order)](#57-assert-the-collection-contains-3-items-and-the-items-match-the-conditions-in-the-declared-order)
  - [5.8. Exceptions](#58-exceptions)
  - [5.9. Object types](#59-object-types)
  - [5.10. Events](#510-events)
- [6. Collections and traits](#6-collections-and-traits)
- [7. Fixtures](#7-fixtures)
- [8. Data driven tests in xUnit.Net](#8-data-driven-tests-in-xunitnet)
  - [8.1. Inline attribute](#81-inline-attribute)
  - [8.2. Property/Method](#82-propertymethod)
- [9. Unit testing legacy code](#9-unit-testing-legacy-code)
  - [9.1. Sprout methods](#91-sprout-methods)
  - [9.2. Sprout class](#92-sprout-class)
- [10. Unit test coverage](#10-unit-test-coverage)
  - [10.1. Command](#101-command)

## 1. What's is xUnit.net

- **xUnit.net** is a free, open source, unit testing tool for the .NET Framework/.NET Core/.NET X. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the .NET Foundation, and operates under their code of conduct.

## 2. Features

- **xUnit.net** supports multiple platforms, you can use for:
- Testing the .NET Framework applications.
- Xamarin applications.
- Writing unit tests, for your .NET Core Applications and including ASP.NET Core.
- Supports parallel tests, execution which will speed up the execution of a unit tests.
- It supports something that we call Data Driven Tests, and that means that when you have a test that will receive different inputs and you will expect different outputs for each input, and instead of writing multiple tests, you can basically write one test and then pass different data to it and then check to see if the output is as expected. It will make your writing test a lot quicker and easier.
- Designed to be extensible, that means that you can add more data types, attributes, assets to xUnit.net and also you can use it alongside other testing frameworks.
- It's very easy to install kind of testing tool, you only install it via NuGet Packages and therefore it's very easy because if you use .Net, you know how to use new get packages.
- Microsoft has adopted xUnit.net as the default and standard unit testing tool. And so if you have visual studio and you have installed .NET Core, when you will create a project and then you want a test project to be added to your solution, that test project by default will be a xUnit.net project.

## 3. Package dependencies

- dotnet add package Microsoft.NET.Test.Sdk
- dotnet add package xunit
- dotnet add package xunit.runner.visualstudio
- dotnet add package Moq
- dotnet add package coverlet.msbuild

## 4. Phases of unit testing

- When you write unit tests, you will have normally three logical phases, and these phases are not specific to xUnit or other framework unit test in general.
- Whatever tool you use to write your unit tests, you will deal with three phases.

### 4.1. Arrange

- Arrange, and that's when you create an instance of your test subject.
  - A test subject is what you are actually testing.
  - You load any data.
  - If you want to actually load data, you read config, you generate your test data.
  - At this stage, it's more like a setup phase.

### 4.2. Act

- Act, and that's when you basically make some calls, you run some code, you do things, that's the code that you run in the block of your unit test method.

### 4.3. Assert

- Assert means you compare the output of your methods, are you of your test code that you run in act phase with the expected values? That's called asset.

## 5. Commons asserts

### 5.1. Any values
```
int value = 0;

Assert.Equal(42, value);
Assert.NotEqual(42, value);
```

### 5.2. Boolean
```
bool b = true;

Assert.True(b, "b should be true");
Assert.False(b, "b should be false");
```

### 5.3. Strings
```
var str = "";

Assert.Equal("", str, ignoreCase: false, ignoreLineEndingDifferences: false, ignoreWhiteSpaceDifferences: false);
Assert.StartsWith("prefix", str, StringComparison.Ordinal);
Assert.EndsWith("suffix", str, StringComparison.Ordinal);
Assert.Matches("[0-9]+", str);
Assert.Contains("jefte", str, StringComparison.InvariantCultureIgnoreCase);
```

### 5.4. Collections
```
var collection = new [] { 1, 2, 3 };

Assert.Empty(collection);
Assert.NotEmpty(collection);
Assert.Single(collection); // Contains only 1 item
Assert.Single(collection, item => item == 1); // Contains only 1 item
Assert.Equal(new int[] { 1, 2, 3 }, collection);
Assert.Contains(0, collection);
Assert.Contains(collection, item => item == 1);
Assert.DoesNotContain(0, collection);
```

### 5.5. Range values

### 5.6. Assert each items of the collection match the condition
```
var age = 35;

Assert.InRange(age, 25, 40);
```

### 5.7. Assert the collection contains 3 items and the items match the conditions (in the declared order)
```
Assert.Collection(collection,
  item => Assert.Equal(1, item),
  item => Assert.Equal(2, item),
  item => Assert.Equal(3, item));
```

### 5.8. Exceptions
```
var ex1 = Assert.Throws<Exception>(() => Console.WriteLine()); // Return the thrown exception
var ex2 = await Assert.ThrowsAsync<Exception>(() => Task.FromResult(1)); // Return the thrown exception
Assert.Equal("message", ex1.Message);
```

### 5.9. Object types
```
var customer = new Customer();
Assert.IsType(typeof(Customer), customer);
```

### 5.10. Events
```
var test = new Test();
Assert.Raises<EventArgs>(
    handler => test.MyEvent += handler,
    handler => test.MyEvent -= handler,
    () => test.RaiseEvent());
```

## 6. Collections and traits
- Grouping tests in xUnit.Net
  - Multiple tests can be grouped into one category
  - Caregories allow us to view and run the tests in batches
  - Grouping is done via `[Trait]` attribute
  - Visual studio for windows is the best tool to work with Groups

Ex:

```
[Fact]
[Trait("Category", "Fibo")]
public void CheckFiboIsNotFour()
{
    /* ... */
}
```

## 7. Fixtures

Ex:
```
public class CalculationsFixture
{
    public Calculations Calculations => new Calculations();
}

public class CalculationsTests : IClassFixture<CalculationsFixture>
{
    private readonly CalculationsFixture _calculationsFixture;

    public CalculationsTests(CalculationsFixture calculationsFixture)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Add_GivenTwoIntValues_ReturnsInt()
    {
        var calculations = _calculationsFixture.Calculations;
        /* ... */
    }

    [Fact]
    public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
    {
        var calculations = _calculationsFixture.Calculations;
        /* ... */
    }
}
```

## 8. Data driven tests in xUnit.Net
|                                 | Shareable | Needs developers |
|---------------------------------|-----------|------------------|
| Inline attribute `[InlineData]` | No        | Yes              |
| Property/Method `[MemberData]`  | Yes       | Yes              |
| Custom attribute                | Yes       | Yes              |
| External data                   | Yes       | No               |

### 8.1. Inline attribute

Ex:
```
[Theory]
[InlineData(1, true)]
[InlineData(200, false)]
public void IsOdd_TestOddAndEven(int value, bool expected)
{
    var calculations = new Calculations;
    Assert.Equal(expected, calculations.IsOdd(value));
}
```

### 8.2. Property/Method

Ex:
```
[Theory]
[MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
public void IsOdd_TestOddAndEvenSharedData(int value, bool expected)
{
    var calculations = _calculationsFixture.Calculations;
    Assert.Equal(expected, calculations.IsOdd(value));
}
```

## 9. Unit testing legacy code

- What's legacy code?
  - Legacy code has many dependencies, does not follow SOLID principles and is hard to test
- Why writting tests for legacy code?
  - To make sure when we change or expand the code we do not introduce bugs
- Should tests be added to the entire project?
  - **NO!**

### 9.1. Sprout methods
- Used when an existing (legacy) method need to be expanded
- Collects the added code into a new methods
- Tests are written for the added methods
- Test driven development can be applied

### 9.2. Sprout class
- Used mainly to eliminate dependencies
- Collects the added come into a new class with similar methods
- Tests are written for the added methods
- Test driven development can be applied

## 10. Unit test coverage
- What is test coverage?
  - The amount of code which has unit tests. Expressed by percentage
- What tools are available?
  - Visual Studio
  - VsCode

### 10.1. Command
- Run code covarage
  - dotnet test /p:CollectCoverage=true
- Run code covarage and export
  - dotnet test /p:CollectCoverage=true /p:CoverletOutput=sprout.xml