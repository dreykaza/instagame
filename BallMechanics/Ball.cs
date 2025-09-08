using Raylib_cs;
using System.Numerics;

namespace Game.BallMechanics;

public class Ball
{
    public int Radius { get; set; }
    // public int Id { get; set; }
    // public Color Color { get; set; }
    // public double Health { get; set; }
    // public int WeaponId { get; set; }
    public Vector2 Coordinate { get; set; }
    public Vector2 Speed { get; set; }
    public float Acceleration { get; set; }
    public Rectangle PlayerHitbox { get; set; }

    public void Move(float frame)
    {
        Coordinate += Speed * Acceleration * frame;
        PlayerHitbox = new Rectangle(Coordinate.X - Radius, Coordinate.Y - Radius, Radius * 2, Radius * 2);
    }

    public void XResistance() =>
        Speed = new(Speed.X > 0 ? Speed.X - 1 : Speed.X + 1, Speed.Y);

    public void Accelerate(Vector2 speed) =>
        Speed += speed;

    public void Gravity(int G) =>
        Speed = new(Speed.X, Speed.Y + G);

    public void InvertX() =>
        Speed = new(-Speed.X, Speed.Y);

    public void InvertY() =>
        Speed = new(Speed.X, -Speed.Y);
}

