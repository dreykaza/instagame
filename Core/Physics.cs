using System.Numerics;
using Game.BallMechanics;
using static Raylib_cs.Raylib;

namespace Game.Core;

public class Physics
{
    public static int[] Collisions;
    public static int[] XStagger = new int[GameHandler.playerCount];
    public static int[] YStagger = new int[GameHandler.playerCount];

    public static void UpdatePlayer(float frame)
    {
        Array.Clear(Collisions);

        for (int i = 0; i < GameHandler.playerCount; i++)
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

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Players[i].Resistance();

        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            switch (Collisions[i])
            {
                case 0:
                    break;
                case 1:
                    if (YStagger[i] <= 0)
                    {
                        GameHandler.Players[i].InvertY();
                        YStagger[i] = 10;
                    }
                    break;
                case 2:
                    if (XStagger[i] <= 0)
                    {
                        GameHandler.Players[i].InvertX();
                        XStagger[i] = 10;
                    }
                    break;
            }
        }

        for (int i = 0; i < XStagger.Length; i++)
        {
            YStagger[i]--;
            XStagger[i]--;
        }

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Players[i].Gravity(Consts.G);

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Players[i].Move(frame);
    }

    public static void InitCollisions() =>
        Collisions = new int[GameHandler.playerCount];
}
