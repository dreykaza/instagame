using Game.BallMechanics;
using Raylib_cs;

namespace Game.Weapons;

public class Dagger : Weapon
{
    public Dagger()
    {
        Id = 1;
        Damage = 1;
        HitBox = new Raylib_cs.Rectangle(Random.Shared.Next(2050), Random.Shared.Next(2500), 52, 30);
        WeaponVec = new System.Numerics.Vector2 { X = -39, Y = 15 };
        RotationSpeed = 10;
        Image img = Raylib.LoadImage("Textures/Dagger.png");
        Raylib.ImageResize(ref img, 55, 30);
        Texture = Raylib.LoadTextureFromImage(img);
        Raylib.UnloadImage(img);
    }

    public override void HitEffect() =>
        RotationSpeed = RotationSpeed > 0 ? RotationSpeed + 5 : RotationSpeed - 5;

    public override string ShowStatistic() =>
        $"{RotationSpeed} RotationSpeed";


}
