using Game.Core;
using Raylib_cs;

namespace Game.BallMechanics;

public class Weapon
{
    public float Speed { get; set; }
    public float Degree { get; set; }
    public Rectangle HitBox { get; set; }
    public int RotationSpeed { get; set; }

    public void Move(int Player) =>
        HitBox = new(GameHandler.Players[Player].Coordinate, HitBox.Width, HitBox.Height);

    public void InvertRotation() =>
        RotationSpeed = -RotationSpeed;
}
