// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Dragonarium.Services.Contexts;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    public static void Main(string[] args)
    {
        ConfigureDb();
    }

    private async static void ConfigureDb()
    {
        var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\", "DragonariumDb.accdb"));
        var ctx = new DragonariumDbContext(path);
        await ctx.Database.MigrateAsync();
    }
}