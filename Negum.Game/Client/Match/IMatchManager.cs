namespace Negum.Game.Client.Match
{
    /// <summary>
    /// Manager used to handle match-related logic.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IMatchManager : IClientModule
    {
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class MatchManager : ClientModule, IMatchManager
    {
        public override void Tick(double deltaTime)
        {
            // TODO: Update current Match
        }
    }
}