// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PokerHandSorter.Application;
using PokerHandSorter.Domain.Game;

try
{
    using IHost host = CreateHostBuilder(args).Build();
    var match = host.Services.GetService<IMatch>();
    match.Play();
    Console.WriteLine($"Player 1: {match.Player1Score} hands");
    Console.WriteLine($"Player 2: {match.Player2Score} hands");
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
}

/// <summary>
/// Dependency injection
/// </summary>
static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services.AddSingleton<IGame, Game>()
                    .AddSingleton<IMatch, Match>());

