// See https://aka.ms/new-console-template for more information
using Quartz;

namespace EnergyPriceChecker;

public class HelloJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await Console.Out.WriteLineAsync("Greetings from HelloJob!");
    }
}