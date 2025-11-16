using Game.BallMechanics;
using Raylib_cs;

namespace Game.Weapons;

public class Sword : Weapon
{
    public Sword()
    {
        Id = 0;
        Damage = 1;
        HitBox = new Raylib_cs.Rectangle(Random.Shared.Next(2000), Random.Shared.Next(2000), 84, 52);
        WeaponVec = new System.Numerics.Vector2 { X = -39, Y = 26 };
        RotationSpeed = 4;
        Image img = Raylib.LoadImage("Textures/Sword.png");
        Raylib.ImageResize(ref img, 87, 50);
        Texture = Raylib.LoadTextureFromImage(img);
        Raylib.UnloadImage(img);
    }

    public override void HitEffect() =>
        Damage++;

    public override string ShowStatistic() =>
        $"{Damage} Damage";
}
