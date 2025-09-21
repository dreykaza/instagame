using Game.Core;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Game;

public class FrameHandler
{
    static float frame;

    public static void GameDraw()
    {
        foreach (var item in Consts.borderRects)
            DrawRectangleRec(item, Color.Gray);

        foreach (var item in GameHandler.Players)
            DrawCircle((int)(item.Coordinate.X), (int)(item.Coordinate.Y), item.Radius, Color.Black);

        foreach (var item in GameHandler.Weapons)
            DrawRectanglePro(item.HitBox, Consts.WeaponVec, item.Degree, Color.Black);
    }

    public static void GameLogic()
    {
        frame = GetFrameTime();
        Collisions.PlayerWeaponCollision();
        Collisions.WeaponCollision();
        Collisions.BorderCollision(frame);
        Physics.PlayerPhysics(frame);
        WeaponHanlder.Spin();
    }
}
