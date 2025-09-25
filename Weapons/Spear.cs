using Game.BallMechanics;

namespace Game.Weapons;

public class Spear : Weapon
{
    public Spear()
    {
        Id = 0;
        Damage = 1;
        HitBox = new Raylib_cs.Rectangle(Random.Shared.Next(200), Random.Shared.Next(200), 85, 40);
        WeaponVec = new System.Numerics.Vector2 { X = 0, Y = 21 };
        RotationSpeed = 4;
    }

    public override void HitEffect()
    {
        Damage += 0.5;
        HitBox = new Raylib_cs.Rectangle(HitBox.X, HitBox.Y, HitBox.Width + 10, HitBox.Height);
    }
}
