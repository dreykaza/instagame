using Game.BallMechanics;
using Raylib_cs;
using System.Numerics;

namespace Game.Core;

public class SAT
{
    public static bool Collision(Weapon First, Ball Player)
    {
        Vector2[] circlePoints =
        {
         new(Player.PlayerHitbox.X, Player.PlayerHitbox.Y),
         new(Player.PlayerHitbox.X + Player.PlayerHitbox.Width, Player.PlayerHitbox.Y),
         new(Player.PlayerHitbox.X + Player.PlayerHitbox.Width, Player.PlayerHitbox.Y + Player.PlayerHitbox.Height),
         new(Player.PlayerHitbox.X, Player.PlayerHitbox.Y + Player.PlayerHitbox.Height)
        };

        Vector2[] WeaponPoints = RotatingRec(First.HitBox, First.Degree, Consts.WeaponVec);

        float[] axes = new float[]
        {
            First.Degree,
            First.Degree + 90,
            0,
            90
        };

        foreach (float axis in axes)
        {
            float[] projA = MinMaxFind(circlePoints, axis);
            float[] projB = MinMaxFind(WeaponPoints, axis);

            if (projA[1] < projB[0] || projB[1] < projA[0])
                return false;
        }

        return true;
    }

    public static bool Collision(Weapon First, Weapon Second)
    {
        Vector2[] firstPoints = RotatingRec(First.HitBox, First.Degree, Consts.WeaponVec);
        Vector2[] secondPoints = RotatingRec(Second.HitBox, Second.Degree, Consts.WeaponVec);

        float[] axes = new float[]
        {
          First.Degree,
          First.Degree + 90,
          Second.Degree,
          Second.Degree + 90
        };

        foreach (float axis in axes)
        {
            float[] projA = MinMaxFind(firstPoints, axis);
            float[] projB = MinMaxFind(secondPoints, axis);

            if (projA[1] < projB[0] || projB[1] < projA[0])
                return false;
        }

        return true;
    }

    public static float[] MinMaxFind(Vector2[] points, float degree)
    {
        double a = degree * Math.PI / 180;
        float[] projection = new float[points.Length];

        for (int i = 0; i < points.Length; i++)
            projection[i] = (float)(points[i].X * Math.Cos(a) + points[i].Y * Math.Sin(a));

        float[] result = new float[] { projection.Min(), projection.Max() };

        return result;
    }


    public static Vector2[] RotatingRec(Rectangle rec, float degree, Vector2 origin)
    {
        Vector2[] result = new Vector2[4];
        double a = degree * Math.PI / 180;

        Vector2[] localCorners =
        {
         new(0, 0),
         new(rec.Width, 0),
         new(rec.Width, rec.Height),
         new(0, rec.Height)
        };

        for (int i = 0; i < 4; i++)
        {
            Vector2 shifted = localCorners[i] - origin;

            Vector2 rotated = new(
                (float)(shifted.X * Math.Cos(a) - shifted.Y * Math.Sin(a)),
                (float)(shifted.X * Math.Sin(a) + shifted.Y * Math.Cos(a))
            );

            result[i] = rotated + origin + new Vector2(rec.X, rec.Y);
        }

        return result;
    }

}
