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

        foreach (var item in GameHandler.Players)
            DrawCircle((int)(item.Coordinate.X), (int)(item.Coordinate.Y), item.Radius, item.Color);

        foreach (var item in GameHandler.Players)
            DrawText(item.Health.ToString(), (int)(item.Coordinate.X - 13), (int)(item.Coordinate.Y - 12), 34, Color.Black);

        foreach (var item in GameHandler.Weapons)
            DrawTexturePro(item.Texture,
                           new Rectangle(0, 0, item.Texture.Width, item.Texture.Height),
                           new Rectangle(item.HitBox.X, item.HitBox.Y, item.HitBox.Width, item.HitBox.Height),
                           item.WeaponVec,
                           item.Degree,
                           Color.White);


        for (int i = 0; i < GameHandler.weaponCount; i++)
        {
            DrawText(GameHandler.Weapons[i].ShowStatistic(), 100 + margin, 10, 34, GameHandler.Players[i].Color);
            margin += 400;
        }

    }

    public static void GameLogic()
    {
        frame = GetFrameTime();
        Collisions.PlayerPlayerCollision();
        Collisions.PlayerWeaponCollision();
        Collisions.WeaponWeaponCollision();
        Collisions.BorderCollision(frame);
        Physics.PlayerPhysics(frame);
        WeaponHanlder.Spin();
    }
}
