using Raylib_cs;

using Game.BallMechanics;

namespace Game.Weapons;

public class Spear : Weapon
{
    public Spear()
    {
        Id = 0;
        Damage = 1;
        HitBox = new Raylib_cs.Rectangle(Random.Shared.Next(2030), Random.Shared.Next(2300), 90, 35);
        WeaponVec = new System.Numerics.Vector2 { X = -39, Y = 21 };
        RotationSpeed = 3;
        Image img = Raylib.LoadImage("Textures/Spear.png");
        Raylib.ImageResize(ref img, 93, 40);
        Texture = Raylib.LoadTextureFromImage(img);
        Raylib.UnloadImage(img);
    }

    public override void HitEffect()
    {
        Damage += 0.5;
        HitBox = new Raylib_cs.Rectangle(HitBox.X, HitBox.Y, HitBox.Width + 5, HitBox.Height);
    }

    public override string ShowStatistic() =>
        $"{Damage} Damage,{HitBox.Width} Width";
}
