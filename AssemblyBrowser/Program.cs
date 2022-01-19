using System;

namespace AssemblyBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Dasha_2\RiderProjects\SPP3\TestClass\bin\Debug\net5.0\TestClass.dll";//@"C:\\Users\\Dasha_2\\RiderProjects\\Tracer\\Tracer\\bin\\Debug\\net5.0\\Tracer.dll";
            ReaderLibrary reader = new ReaderLibrary();
            reader.GetResult(path);
            Console.WriteLine(reader.ToString());
        }
    }
}