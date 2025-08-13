using Game.BallMechanics;
using static Raylib_cs.Raylib;

namespace Game.Core;

public class Physics
{
    public static int playerCount = GameHandler.Players.Length;
    public static int[] Collisions = new int[playerCount];

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
                    GameHandler.Players[i].InvertY();
                    break;
                case 2:
                    GameHandler.Players[i].InvertX();
                    break;
            }
        }
    }
}
