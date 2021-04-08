using Negum.Game.Common.Entities;

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
        /// <summary>
        /// Tries to return Player based on the specified Id.
        ///
        /// For single-player:
        /// 0 - Player 1
        /// 1 - Player 2
        ///
        /// For multi-player:
        /// X - Returns the player from the server
        /// </summary>
        /// <param name="playerId">Indicates the appropriate number of the Player.</param>
        /// <returns>Returns the Player based on the given Id.</returns>
        Player GetPlayer(int playerId);
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

        public virtual Player GetPlayer(int playerId)
        {
            // TODO: This should return player based on ID - check interface description
            return new Player();
        }
    }
}