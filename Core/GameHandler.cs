using Game.BallMechanics;

namespace Game.Core;

public class GameHandler
{
    public static Ball[] Players;
    public static Weapon[] Weapons;

    public static int playerCount => Players.Length;

    public static void Init(int Count)
    {
        PlayersInit(Count);
        Physics.InitCollisions();
        WeaponInit(Count);
    }

    public static void PlayersInit(int Count)
    {
        Players = new Ball[Count];
        for (int i = 0; i < Count; i++)
        {
            Players[i] = new Ball
            {
                Radius = 20,
                SpeedY = 0.0f,
                SpeedX = 0.0f,
                Coordinate = new System.Numerics.Vector2 { X = 450, Y = 450 },
                Acceleration = 0f
            };
        }
    }

    public static void WeaponInit(int Count)
    {
        Weapons = new Weapon[Count];
        for (int i = 0; i < Count; i++)
        {
            Weapons[i] = new Weapon
            {
                Speed = 0,
                Rotation = 0,
                HitBox = new Raylib_cs.Rectangle(GameHandler.Players[0].Coordinate, 75, 25)
            };
        }
    }

}
