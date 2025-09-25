using Game.BallMechanics;

namespace Game.Weapons;

public class Sword : Weapon
{
    public Sword()
    {
        Id = 0;
        Damage = 1;
        HitBox = new Raylib_cs.Rectangle(Random.Shared.Next(200), Random.Shared.Next(200), 90, 40);
        WeaponVec = new System.Numerics.Vector2 { X = 0, Y = 25 };
        RotationSpeed = 4;
    }

    public override void HitEffect() =>
        Damage++;
}
