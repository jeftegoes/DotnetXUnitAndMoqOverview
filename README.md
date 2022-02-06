# xUnit.net overview <!-- omit in toc -->

## Contents <!-- omit in toc -->



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