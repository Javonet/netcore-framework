using System;

namespace ConsoleApp1
{
    using Javonet.Clr.Sdk;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from .NET Framework code!");

            RuntimeContext context = Javonet.WithConfig("./javonetconf.json").Netcore("dockerimage");
            string className = "WebApi.TestClass";
            string staticClassName = "WebApi.TestStaticClass";

            // get type from the runtime
            var calledRuntimeType = context.GetType(className).Execute();

            // creating an instance of class
            var instance = calledRuntimeType.CreateInstance().Execute();

            // invoking instance method
            var response = instance.InvokeInstanceMethod("TestMethod", "Adam").Execute();
            Console.WriteLine(response.GetValue());

            // get static type from the runtime
            var calledStaticRuntimeType = context.GetType(staticClassName).Execute();

            // invoking static method
            var staticResponse = calledStaticRuntimeType.InvokeStaticMethod("TestMethod", "Adam").Execute();
            Console.WriteLine(staticResponse.GetValue());
        }
    }
}
