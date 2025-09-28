using Game.BallMechanics;
using Raylib_cs;

namespace Game.Weapons;

public class Sword : Weapon
{
    public Sword()
    {
        Id = 0;
        Damage = 1;
        HitBox = new Raylib_cs.Rectangle(Random.Shared.Next(2000), Random.Shared.Next(2000), 90, 40);
        WeaponVec = new System.Numerics.Vector2 { X = 0, Y = 20 };
        RotationSpeed = 4;
        Texture = Raylib.LoadTexture(Path.Combine("Textures", "Sword.png"));
    }

    public override void HitEffect() =>
        Damage++;

    public override string ShowStatistic() =>
        $"{Damage} Damage";
}
