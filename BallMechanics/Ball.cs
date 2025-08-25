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
    public float SpeedX { get; set; }
    public float SpeedY { get; set; }
    public Rectangle PlayerHitbox { get; set; }

    public void Move(float dx, float dy)
    {
        Coordinate = new Vector2(Coordinate.X + dx, Coordinate.Y + dy);
        PlayerHitbox = new Rectangle(Coordinate.X - Radius, Coordinate.Y - Radius, Radius * 2, Radius * 2);
    }
}


