using System.Numerics;
using Game.BallMechanics;
using Game.Weapons;

namespace Game.Core;

public class GameHandler
{
    public static int ConflTimer = 0;
    public static List<Ball> Players = [];
    public static List<Weapon> Weapons = [];
    private static readonly Random rng = new();
    public static int playerCount => Players.Count;
    public static int weaponCount => Weapons.Count;

    public static void Init(int[] Health, int[] WeaponType)
    {
        PlayersInit(Health);
        WeaponInit(WeaponType);
        _ = Task.Run(() => ConflictTimer());
    }

    public static void PlayersInit(int[] Health)
    {
        for (int i = 0; i < Health.Length; i++)
        {
            Players.Add(
                    new Ball
                    {
                        Radius = 45,
                        Color = GenerateColor(),
                        Health = Health[i],
                        Speed = new Vector2 { X = 0, Y = 0 },
                        Coordinate = GetRandomPositionInsideBorder(),
                        Acceleration = 1
                    });
        }
    }

    public static void WeaponInit(int[] Type)
    {
        for (int i = 0; i < Type.Length; i++)
            Weapons.Add(WeaponFactory.Create(Type[i]));
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
                                                GameHandler.Players[j].Coordinate) * 0.5f;
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

    public static Raylib_cs.Color GenerateColor()
    {
        while (true)
        {
            int r = (byte)Random.Shared.Next(0, 256);
            int g = (byte)Random.Shared.Next(0, 256);
            int b = (byte)Random.Shared.Next(0, 256);


            double luminance = 0.2126 * r + 0.7152 * g + 0.0722 * b;

            if (luminance >= 80 && luminance <= 175)
            {
                return new Raylib_cs.Color(r, g, b, 255);
            }
        }
    }
}
