namespace Game.Core;

public class Physics
{
    public static void PlayerPhysics(float frame)
    {
        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Players[i].Resistance();

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Players[i].Gravity(Consts.G);

        for (int i = 0; i < GameHandler.playerCount; i++)
            GameHandler.Players[i].Move(frame);
    }
}
