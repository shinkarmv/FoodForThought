using Microsoft.Extensions.DependencyInjection;
using SnakeAndLadders.Contracts;
using System;

namespace SnakeAndLadders.Host
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            Execute();
            DisposeServices();
        }

        private static void Execute()
        {
            Console.WriteLine("Started the game");
            Console.WriteLine();
            IServiceScope scope = _serviceProvider.CreateScope();
            int postion;
            do
            {
                postion = scope.ServiceProvider.GetRequiredService<RollTheDice>().NextMove();
            } while (postion < 100);

            Console.WriteLine("Completed the game");
            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<ISnakeAndLadders, SnakeAndLadders>();
            services.AddTransient<IBoard, Board>();
            services.AddTransient<IDice, Dice>();
            services.AddSingleton<RollTheDice>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
