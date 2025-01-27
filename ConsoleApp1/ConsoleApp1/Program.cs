using System;

namespace ConsoleApp1
{
    using Javonet.Clr.Sdk;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World from .NET Framework code!");

            RuntimeContext context = Javonet.WithConfig("./javonetconf.json").Netcore("dockerimage");

            string libraryPath = "/app";
            string className = "WebApi.TestClass";
            // string staticClassName = "WebApi.TestStaticClass";
            try
            {
                context.LoadLibrary(libraryPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                // load custom library
             //   context.LoadLibrary(libraryPath);

            // get type from the runtime
            var calledRuntimeType = context.GetType(className).Execute();
            var instance = calledRuntimeType.CreateInstance().Execute();
            instance.InvokeInstanceMethod("TestMethod").Execute();

            // var calledRuntimeTypeForStatic = calledRuntime.GetType(staticClassName).Execute();
            // calledRuntimeTypeForStatic.InvokeStaticMethod("TestMethod").Execute();
        }
    }
}
