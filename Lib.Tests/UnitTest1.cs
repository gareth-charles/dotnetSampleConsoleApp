using NUnit.Framework;

namespace Lib.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.AreEqual(Class1.Describe(), "This is Class1!", "We should be able to get this string from Class1.");
    }
}
