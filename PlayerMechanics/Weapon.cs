using System.Numerics;
using Game.Core;
using Raylib_cs;

namespace Game.BallMechanics;

public abstract class Weapon
{
    //
    public int Id { get; set; }
    public double Damage { get; set; }
    public Vector2 WeaponVec { get; set; }
    public Rectangle HitBox { get; set; }
    public int RotationSpeed { get; set; }
    public Texture2D Texture { get; set; }
    //
    public float Degree { get; set; }
    public float Speed { get; set; }

    public abstract void HitEffect();

    public abstract string ShowStatistic();

    public void Move(int Player) =>
        HitBox = new(GameHandler.Players[Player].Coordinate, HitBox.Width, HitBox.Height);

    public void InvertRotation() =>
        RotationSpeed = -RotationSpeed;
}
