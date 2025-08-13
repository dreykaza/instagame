using System.Numerics;
using Raylib_cs;

namespace Game.BallMechanics;

public class Ball
{
    public int Radius { get; set; }
    public int Id { get; set; }
    public Color Color { get; set; }
    public double Health { get; set; }
    public int WeaponId { get; set; }
    public Vector2 Coordinate { get; set; }
    public float Speed { get; set; }

    public void InvertY()
    {
        Coordinate = new Vector2(Coordinate.X, -Coordinate.Y);
    }

    public void InvertX()
    {
        Coordinate = new Vector2(-Coordinate.X, Coordinate.Y);
    }
}


