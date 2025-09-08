using Raylib_cs;
using static Raylib_cs.Raylib;
using Game.Core;
namespace Game;

class Program
{
    static void Main(string[] args)
    {
        float frame;
        Raylib.InitWindow(Consts.Screen, Consts.Screen, "Insta game");
        Raylib.SetTargetFPS(60);
        GameHandler.Init(2);
        while (!Raylib.WindowShouldClose())
        {
            BeginDrawing();
            Screen.Draw();
            frame = GetFrameTime();
            WeaponHanlder.PlayerWeaponCollision();
            WeaponHanlder.WeaponCollision();
            Physics.UpdatePlayer(frame);
            WeaponHanlder.Spin();
            EndDrawing();
        }
    }
}
