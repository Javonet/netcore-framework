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
            string className = "WebApi.TestClass";
        

            // get type from the runtime
            var calledRuntimeType = context.GetType(className).Execute();
            var instance = calledRuntimeType.CreateInstance().Execute();
            var response = instance.InvokeInstanceMethod("TestMethod", "abc").Execute();
            Console.WriteLine(response.GetValue());
        }
    }
}
