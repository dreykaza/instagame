using System.Numerics;
using Game.Core;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Game;

public class FrameHandler
{
    static float frame;

    public static void GameDraw()
    {
        int margin = 0;

        foreach (var item in Consts.borderRects)
            DrawRectangleRec(item, Color.Gray);

        foreach (var item in GameHandler.Weapons)
            DrawRectanglePro(item.HitBox, item.WeaponVec, item.Degree, Color.Black);

        foreach (var item in GameHandler.Players)
            DrawCircle((int)(item.Coordinate.X), (int)(item.Coordinate.Y), item.Radius, item.Color);

        foreach (var item in GameHandler.Players)
            DrawText(item.Health.ToString(), (int)(item.Coordinate.X - 13), (int)(item.Coordinate.Y - 12), 34, Color.Black);

        for (int i = 0; i < GameHandler.weaponCount; i++)
        {
            DrawText(GameHandler.Weapons[i].ShowStatistic(), 100 + margin, 10, 34, GameHandler.Players[i].Color);
            margin += 300;
        }

        Rectangle src = new Rectangle(0, 0, 90, 40);
        Rectangle dest = new Rectangle(100, 100, 64, 64); // финальный размер
        Raylib.DrawTexturePro(GameHandler.Weapons[0].Texture, src, dest, new Vector2(0, 0), 0f, Color.White);
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
