using Raylib_cs;
using static Raylib_cs.Raylib;
using Game.Core;
namespace Game;

class Program
{
    static void Main(string[] args)
    {
        Raylib.InitWindow(Consts.Screen, Consts.Screen, "Insta game");
        Raylib.SetTargetFPS(60);
        GameHandler.PlayersInit();
        Physics.InitCollisions();
        while (!Raylib.WindowShouldClose())
        {
            BeginDrawing();
            Physics.frameUp();
            Physics.UpdatePlayer();
            Screen.Draw();
            EndDrawing();
        }
    }
}
