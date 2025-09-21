using System.Numerics;
using Game.BallMechanics;

namespace Game.Core;

public class GameHandler
{
    public static int ConflTimer = 0;
    public static List<Ball> Players = [];
    public static List<Weapon> Weapons = [];
    private static readonly Random rng = new();
    public static int playerCount => Players.Count;
    public static int weaponCount => Weapons.Count;

    public static void Init(int Count)
    {
        PlayersInit(Count);
        WeaponInit(Count);
        Collisions.InitCollisions();
        _ = Task.Run(() => ConflictTimer());
    }

    public static void PlayersInit(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            Players.Add(
                    new Ball
                    {
                        Radius = 35,
                        Speed = new Vector2 { X = 0, Y = 0 },
                        Coordinate = GetRandomPositionInsideBorder(),
                        Acceleration = 1
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
                        RotationSpeed = 4
                    });
        }
    }

    public static void ConflictTimer()
    {
        while (true)
        {
            ConflTimer--;
            if (ConflTimer < 0)
                for (int i = 0; i < playerCount; i++)
                    for (int j = 0; j < playerCount; j++)
                    {
                        if (i == j) continue;

                        Vector2 Acceleration = (GameHandler.Players[i].Coordinate -
                                                GameHandler.Players[j].Coordinate) * 1f;
                        GameHandler.Players[i].Accelerate(-Acceleration);

                        ConflTimer = 100;
                    }
            Thread.Sleep(17);
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
