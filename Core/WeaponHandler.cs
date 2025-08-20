using static Raylib_cs.Raylib;

namespace Game.Core;

public class WeaponHanlder
{
    public static int[] WeaponStagger = new int[GameHandler.weaponCount];

    public static void Spin()
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Weapons[i].Degree += GameHandler.Weapons[i].RotationSpeed;

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Weapons[i].Move(i);
    }

    public static void WeaponCollision()
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            for (int j = 0; j < GameHandler.weaponCount; j++)
            {
                if (i == j) continue;
                if (CheckCollisionCircleRec(GameHandler.Players[i].Coordinate, GameHandler.Players[i].Radius, GameHandler.Weapons[j].HitBox))
                {
                    if (WeaponStagger[j] <= 0)
                    {
                        GameHandler.Weapons[j].InvertRotation();
                        WeaponStagger[j] = 50;
                    }

                }
            }
        }
        for (int i = 0; i < WeaponStagger.Length; i++)
            WeaponStagger[i]--;
    }

}
