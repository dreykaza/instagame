using Game.BallMechanics;
using Raylib_cs;
using System.Numerics;

namespace Game.Core;

public class SAT
{
    public static bool Collision(Weapon First, Weapon Second)
    {
        float[][] frstAxisMM = new float[][]
        {
          MinMaxFind(RotatingRec(GetRectangleCorners(First.HitBox),First.Degree),First.Degree),
          MinMaxFind(RotatingRec(GetRectangleCorners(First.HitBox), Second.Degree), Second.Degree)
        };
        float[][] scndAxisMM = new float[][]
        {
          MinMaxFind(RotatingRec(GetRectangleCorners(Second.HitBox),First.Degree),First.Degree),
          MinMaxFind(RotatingRec(GetRectangleCorners(Second.HitBox), Second.Degree), Second.Degree)
        };

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

    public static Vector2[] RotatingRec(Vector2[] points, float degree)
    {
        Vector2[] result = new Vector2[points.Length];
        double a = degree * Math.PI / 180;

        for (int i = 0; i < points.Length; i++)
        {
            Vector2 shifted = points[i] + Consts.WeaponVec;

            Vector2 rotated = new Vector2(
                (float)(Math.Cos(a) * Consts.WeaponVec.X - Math.Sin(a) * Consts.WeaponVec.Y),
                (float)(Math.Sin(a) * Consts.WeaponVec.X + Math.Cos(a) * Consts.WeaponVec.Y)
            );

            result[i] = shifted + rotated;
        }

        return result;
    }

    public static Vector2[] GetRectangleCorners(Rectangle rec) =>
        new Vector2[]
        {
          new Vector2(rec.X, rec.Y),
          new Vector2(rec.X + rec.Width, rec.Y),
          new Vector2(rec.X + rec.Width, rec.Y + rec.Height),
          new Vector2(rec.X, rec.Y + rec.Height)
        };

}
