using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Game;

class Program
{
    static void Main(string[] args)
    {
        Raylib.InitWindow(Consts.Screen, Consts.Screen, "Insta game");
        Raylib.SetTargetFPS(60);
        while (!Raylib.WindowShouldClose())
        {
            BeginDrawing();
            Screen.Draw();
            EndDrawing();
        }
    }
}
