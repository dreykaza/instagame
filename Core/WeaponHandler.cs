namespace Game.Core;

public class WeaponHanlder
{
    public static int[] WeaponStagger = new int[GameHandler.weaponCount];

    public static void Spin()
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Weapons[i].Degree += GameHandler.Weapons[i].RotationSpeed;

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Weapons[i].Move(i);
    }

    public static void WeaponCollision()
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
        {
            for (int j = 0; j < GameHandler.weaponCount; j++)
            {
                if (i == j) continue;
                if (SAT.Collision(GameHandler.Weapons[i], GameHandler.Weapons[j]))
                {
                    if (WeaponStagger[j] <= 0)
                    {
                        GameHandler.Weapons[j].InvertRotation();
                        WeaponStagger[j] = new Random().Next(25, 52);
                    }
                }
            }
        }
        for (int i = 0; i < WeaponStagger.Length; i++)
            WeaponStagger[i]--;
    }

}
