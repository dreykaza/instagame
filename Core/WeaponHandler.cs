namespace Game.Core;

public class WeaponHanlder
{
    public static void Spin()
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Weapons[i].Degree += GameHandler.Weapons[i].RotationSpeed;

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Weapons[i].Move(i);
    }
}
