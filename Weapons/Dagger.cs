using Game.BallMechanics;

namespace Game.Weapons;

public class Dagger : Weapon
{
    public Dagger()
    {
        Id = 1;
        Damage = 1;
        HitBox = new Raylib_cs.Rectangle(Random.Shared.Next(200), Random.Shared.Next(200), 75, 30);
        WeaponVec = new System.Numerics.Vector2 { X = 0, Y = 17 };
        RotationSpeed = 10;
    }

    public override void HitEffect() =>
        RotationSpeed += 5;

}
