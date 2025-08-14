using Game.BallMechanics;

namespace Game.Core;

public class GameHandler
{
    public static Ball[] Players;

    public GameHandler()
    {
        PlayersInit();
    }

    public static void PlayersInit()
    {
        Players = new Ball[1];
        Players[0] = new Ball
        {
            Radius = 10,
            SpeedY = 200.0f,
            SpeedX = 200.0f,
            Coordinate = new System.Numerics.Vector2 { X = 450, Y = 450 }
        };


    }
}
