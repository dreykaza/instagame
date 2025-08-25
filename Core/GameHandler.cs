using System.Numerics;
using Game.BallMechanics;

namespace Game.Core;

public class GameHandler
{
    public static List<Ball> Players = [];
    public static List<Weapon> Weapons = [];
    private static readonly Random rng = new();
    public static int playerCount => Players.Count;
    public static int weaponCount => Weapons.Count;

    public static void Init(int Count)
    {
        PlayersInit(Count);
        Physics.InitCollisions();
        WeaponInit(Count);
    }

    public static void PlayersInit(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            Players.Add(
                    new Ball
                    {
                        Radius = 35,
                        SpeedY = 0.0f,
                        SpeedX = 0.0f,
                        Coordinate = GetRandomPositionInsideBorder(),
                    });
        }
    }

    public static void WeaponInit(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            Weapons.Add(
                    new Weapon
                    {
                        Speed = 0,
                        Degree = 0,
                        HitBox = new Raylib_cs.Rectangle(GameHandler.Players[i].Coordinate, 100, 50),
                        RotationSpeed = 2
                    });
        }
    }


    public static Vector2 GetRandomPositionInsideBorder()
    {
        int minX = Consts.leftMargin + Consts.borderThickness + 100;
        int maxX = Consts.leftMargin + Consts.central - Consts.borderThickness - 100;

        int minY = Consts.leftMargin + Consts.borderThickness + 100;
        int maxY = Consts.leftMargin + Consts.central - Consts.borderThickness - 100;

        int x = rng.Next(minX, maxX);
        int y = rng.Next(minY, maxY);

        return new Vector2(x, y);
    }

}
