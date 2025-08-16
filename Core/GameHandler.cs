using Game.BallMechanics;

namespace Game.Core;

public class GameHandler
{
    public static Ball[] Players;

    public static void Init(int Count)
    {
        PlayersInit(Count);
        Physics.InitCollisions();
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
}
