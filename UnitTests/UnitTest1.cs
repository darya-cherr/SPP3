using System.Collections.Generic;
using AssemblyBrowser;
using NUnit.Framework;
using Namespace1;
using Namespace2;
using Namespace3;

public class TestClass
{
    string path = @"C:\Users\Dasha_2\RiderProjects\SPP3\TestClass\bin\Debug\net5.0\TestClass.dll";
    ReaderLibrary reader;

    public TestClass()
    {
        reader = new ReaderLibrary();
        reader.GetResult(path);
        
    }
    
    [Test]
    public void TestNamespacesCount()
    {
        int result = 0;
        foreach (var type in reader.typeList)
        {
            if (type._nameSpace != "")
                result++;
        }
        Assert.AreEqual(result, 3);
    }
    
    [Test]
    public void TestNamespaceName()
    {
        Assert.AreEqual(reader.typeList[0]._nameSpace, nameof(Namespace1));
        Assert.AreEqual(reader.typeList[1]._nameSpace, nameof(Namespace2));
        Assert.AreEqual(reader.typeList[2]._nameSpace, nameof(Namespace3));
    }

    [Test]
    public void TestMethodCountClassB()
    {
        Assert.AreEqual(reader.typeList[1]._methods.Count, 2);
    }
    
    [Test]
    public void TestPropertiesCountClassC()
    {
        Assert.AreEqual(reader.typeList[2]._properties.Count, 2);
    }
    
    [Test]
    public void TestFieldsCountClassA()
    {
        Assert.AreEqual(reader.typeList[0]._fields.Count, 4);
    }
}

