using static Raylib_cs.Raylib;

namespace Game.Core;

public class Physics
{

    public static float frame;
    public static int[] Collisions;
    public static int playerCount;
    public static void UpdatePlayer()
    {
        //0 - nothing 1 - top, bottom
        //2 - right, left

        for (int i = 0; i < playerCount; i++)
        {
            Collisions[i] = 0;
        }

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
                    GameHandler.Players[i].SpeedY *= -1;
                    break;
                case 2:
                    GameHandler.Players[i].SpeedX *= -1;
                    break;
            }
        }

        for (int i = 0; i < GameHandler.Players.Length; i++)
        {
            GameHandler.Players[i].Move(GameHandler.Players[i].SpeedX * frame, GameHandler.Players[i].SpeedY * frame);
        }
    }

    public static void InitCollisions()
    {
        playerCount = GameHandler.Players.Length;
        Collisions = new int[playerCount];
    }
    public static void frameUp()
    {
        frame = GetFrameTime();
    }
}
