using Game.Core;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace Game;

public class Screen
{
    public static void Draw()
    {
        ClearBackground(Color.White);
        foreach (var item in Consts.borderRects)
        {
            DrawRectangleRec(item, Color.Gray);
        }
        DrawCircle((int)(GameHandler.Players[0].Coordinate.X), (int)(GameHandler.Players[0].Coordinate.Y), 10, Color.Black);
    }
}
