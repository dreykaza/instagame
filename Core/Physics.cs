using static Raylib_cs.Raylib;

namespace Game.Core;

public class Physics
{
    public static int[] Collisions;
    public static int playerCount;
    public static int XStagger = 0;
    public static int YStagger = 0;

    public static void UpdatePlayer(float frame)
    {
        for (int i = 0; i < playerCount; i++)
            Collisions[i] = 0;

        for (int i = 0; i < playerCount; i++)
        {
            for (int j = 0; j < Consts.borderRects.Length; j++)
            {
                if (CheckCollisionCircleRec(GameHandler.Players[i].Coordinate, GameHandler.Players[i].Radius, Consts.borderRects[j]))
                {
                    Collisions[i] = j < 2 ? 1 : 2;
                    break;
                }
            }
        }

        for (int i = 0; i < playerCount; i++)
        {
            switch (Collisions[i])
            {
                case 0:
                    break;
                case 1:
                    if (YStagger <= 0)
                    {
                        GameHandler.Players[i].SpeedY *= -1;
                        YStagger = 50;
                    }
                    break;
                case 2:
                    if (XStagger <= 0)
                    {
                        GameHandler.Players[i].SpeedX *= -1;
                        XStagger = 50;
                    }
                    break;
            }
        }
        YStagger -= 1;
        XStagger -= 1;
        for (int i = 0; i < playerCount; i++)
            GameHandler.Players[i].SpeedY += Consts.G;

        for (int i = 0; i < playerCount; i++)
            GameHandler.Players[i].Move(GameHandler.Players[i].SpeedX * frame, GameHandler.Players[i].SpeedY * frame);
    }

    public static void InitCollisions()
    {
        playerCount = GameHandler.Players.Length;
        Collisions = new int[playerCount];
    }
}
