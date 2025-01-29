using System;

namespace FrameworkConsoleApp
{
    using Javonet.Clr.Sdk;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World from .NET Framework code!");
            
            Javonet.Activate("n9B5-Km7g-Pp69-j9FE-e9A5");

            var calledRuntime = Javonet.InMemory().Netcore();

            string libraryPath = @"D:\Proksy\javonet\netcore-framework\FrameworkConsoleApp\FrameworkConsoleApp\NetCoreClassLibrary.dll";
            string className = "NetCoreClassLibrary.TestClass";
            string staticClassName = "NetCoreClassLibrary.TestStaticClass";

            // load custom library
            calledRuntime.LoadLibrary(libraryPath);

            // get type from the runtime
            InvocationContext calledRuntimeType = calledRuntime.GetType(className).Execute();
            InvocationContext instance = calledRuntimeType.CreateInstance().Execute();
            InvocationContext response = instance.InvokeInstanceMethod("TestMethod", "Adam").Execute();
            Console.WriteLine(response.GetValue());

            var calledRuntimeTypeForStatic = calledRuntime.GetType(staticClassName).Execute();
            var staticResponse = calledRuntimeTypeForStatic.InvokeStaticMethod("TestMethod", "Adam").Execute();
            Console.WriteLine(staticResponse.GetValue());
        }
    }
}
