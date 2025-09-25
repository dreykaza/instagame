using Game.BallMechanics;

namespace Game.Weapons;

public class WeaponFactory
{
    private static readonly Dictionary<int, Func<Weapon>> weapons = new()
    {
        { 0, () => new Sword() },
        { 1, () => new Dagger()},
        { 2, () => new Spear()},
    };

    public static Weapon Create(int id)
    {
        return weapons.ContainsKey(id) ? weapons[id]() : null;
    }
}
