using ManualProxyCreation.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;

namespace ManualProxyCreation.CLI

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("Config/config.json").Build();

            Console.WriteLine(config["test"]);



        }
    }
}