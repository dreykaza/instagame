using System.Numerics;
using static Raylib_cs.Raylib;

namespace Game.Core;

public class Collisions
{
    public static int[] BorderCollisions = new int[GameHandler.playerCount];
    public static int[] XStagger = new int[GameHandler.playerCount];
    public static int[] YStagger = new int[GameHandler.playerCount];
    public static int[] WeaponStagger = new int[GameHandler.weaponCount];
    public static int[] HitStagger = new int[GameHandler.weaponCount];

    public static void BorderCollision(float frame)
    {
        Array.Clear(BorderCollisions);

        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            for (int j = 0; j < Consts.borderRects.Length; j++)
            {
                if (CheckCollisionCircleRec(GameHandler.Players[i].Coordinate, GameHandler.Players[i].Radius, Consts.borderRects[j]))
                {
                    BorderCollisions[i] = j < 2 ? 1 : 2;
                    break;
                }
            }
        }
        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            switch (BorderCollisions[i])
            {
                case 0:
                    break;
                case 1:
                    if (YStagger[i] <= 0)
                    {
                        GameHandler.Players[i].InvertY();
                        YStagger[i] = 5;
                    }
                    break;
                case 2:
                    if (XStagger[i] <= 0)
                    {
                        GameHandler.Players[i].InvertX();
                        XStagger[i] = 5;
                    }
                    break;
            }
        }

        for (int i = 0; i < XStagger.Length; i++)
        {
            YStagger[i]--;
            XStagger[i]--;
        }
    }

    public static void PlayerWeaponCollision()
    {
        int toRemove = -1;

        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            for (int j = 0; j < GameHandler.weaponCount; j++)
            {
                if (i == j) continue;
                if (SAT.Collision(GameHandler.Weapons[j], GameHandler.Players[i]))
                {
                    if (HitStagger[j] < 0)
                    {
                        GameHandler.Weapons[j].InvertRotation();
                        GameHandler.Players[i].Health -= GameHandler.Weapons[j].Damage;
                        GameHandler.Weapons[j].HitEffect();
                        HitStagger[j] = 5;
                        toRemove = i;
                    }
                    break;
                }
            }
        }

        for (int i = 0; i < HitStagger.Length; i++)
            HitStagger[i]--;

        if (toRemove != -1)
        {
            GameHandler.ConflTimer = 400;
            if (GameHandler.Players[toRemove].Health <= 0)
            {
                GameHandler.Players.RemoveAt(toRemove);
                GameHandler.Weapons.RemoveAt(toRemove);
            }
        }

    }

    public static void PlayerPlayerCollision()
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            for (int j = 0; j < GameHandler.playerCount; j++)
            {
                if (i == j) continue;
                if (CheckCollisionCircles(GameHandler.Players[i].Coordinate,
                                          GameHandler.Players[i].Radius,
                                          GameHandler.Players[j].Coordinate,
                                          GameHandler.Players[j].Radius))
                {
                    Vector2 Acceleration = (GameHandler.Players[i].Coordinate -
                                            GameHandler.Players[j].Coordinate) * 1.5f;
                    GameHandler.Players[i].Accelerate(Acceleration);

                }
            }
        }
    }

    public static void WeaponWeaponCollision()
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            for (int j = 0; j < GameHandler.weaponCount; j++)
            {
                if (i == j) continue;
                if (SAT.Collision(GameHandler.Weapons[i], GameHandler.Weapons[j]))
                {
                    if (WeaponStagger[j] <= 0)
                    {
                        GameHandler.Weapons[j].InvertRotation();

                        for (int k = 0; k < GameHandler.playerCount; k++)
                            for (int g = 0; g < GameHandler.playerCount; g++)
                            {
                                if (k == g) continue;

                                Vector2 Acceleration = (GameHandler.Players[k].Coordinate -
                                                        GameHandler.Players[g].Coordinate) * 1.5f;
                                GameHandler.Players[k].Accelerate(Acceleration);
                            }

                        GameHandler.ConflTimer = 400;
                        WeaponStagger[j] = new Random().Next(15, 52);
                    }
                }
            }
        }
        for (int i = 0; i < WeaponStagger.Length; i++)
            WeaponStagger[i]--;
    }
}
