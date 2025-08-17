using Raylib_cs;

namespace Game;

public class Consts
{
    private static readonly int leftMargin = (int)(Screen * 0.05);
    private static readonly int central = (int)(Screen * 0.9);

    public const int G = 5;

    public static System.Numerics.Vector2 WeaponVec = new System.Numerics.Vector2 { X = 0, Y = 13 };

    public const int Screen = 900;
    private const int borderThickness = 10;

    public static readonly Rectangle[] borderRects =
    {
        new Rectangle(leftMargin, leftMargin, central, borderThickness),
        new Rectangle(leftMargin, leftMargin + central - borderThickness, central, borderThickness),
        new Rectangle(
            leftMargin,
            leftMargin + borderThickness,
            borderThickness,
            central - borderThickness * 2
        ),
        new Rectangle(
            leftMargin + central - borderThickness,
            leftMargin + borderThickness,
            borderThickness,
            central - borderThickness * 2
        ),
    };
}
