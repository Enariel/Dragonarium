// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Dragonarium.Services.Contexts;

internal class Program
{
    public static void Main(string[] args)
    {
        var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\", "DragonariumDb.accdb"));
        var ctx = new DragonariumDbContext(path);
        ctx.Database.EnsureCreated();
    }
}