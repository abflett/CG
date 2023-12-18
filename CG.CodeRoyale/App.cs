// Using dotnet-combine to merge multiple source files into one
// https://github.com/eduherminio/dotnet-combine
// dotnet-combine single-file C:\Dev\Source\CG\CG.CodeRoyale --output  C:\Dev\Source\CodingGame\CodeRoyal.cs --overwrite true

class App
{
    static void Main(string[] args)
    {
        Game game = new();
        game.Run();
    }
}