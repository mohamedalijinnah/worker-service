// See https://aka.ms/new-console-template for more information
using EnergyPriceChecker;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

Console.WriteLine("Hello, World!");


LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

// Grab the Scheduler instance from the Factory
StdSchedulerFactory factory = new();
IScheduler scheduler = await factory.GetScheduler();

// and start it off
await scheduler.Start();

// define the job and tie it to our HelloJob class
IJobDetail job = JobBuilder.Create<HelloJob>()
    .WithIdentity("job1", "group1")
    .Build();

// Trigger the job to run now, and then repeat every 10 seconds
ITrigger trigger = TriggerBuilder.Create()
    .WithIdentity("trigger1", "group1")
    .StartNow()
    .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(10)
        .RepeatForever())
    .Build();

// Tell quartz to schedule the job using our trigger
await scheduler.ScheduleJob(job, trigger);

// some sleep to show what's happening
await Task.Delay(TimeSpan.FromSeconds(60));

// and last shut down the scheduler when you are ready to close your program
await scheduler.Shutdown();

Console.WriteLine("Press any key to close the application");
Console.ReadKey();
