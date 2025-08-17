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
        GameHandler.Init(1);
        while (!Raylib.WindowShouldClose())
        {
            BeginDrawing();
            float frame = GetFrameTime();
            Physics.UpdatePlayer(frame);
            WeaponHanlder.Spin();
            Screen.Draw();
            EndDrawing();
        }
    }
}
