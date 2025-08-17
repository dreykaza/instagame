using Game.Core;
using Raylib_cs;

namespace Game.BallMechanics;

public class Weapon
{
    public float Speed { get; set; }
    public float Rotation { get; set; }
    public Rectangle HitBox { get; set; }

    public void Move(int Player)
    {
        HitBox = new(GameHandler.Players[Player].Coordinate, 75, 25);
    }
}
