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
    }
}
