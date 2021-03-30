using System.Collections.Generic;

namespace Negum.Game.Common.Entities
{
    /// <summary>
    /// Represents a single Team in match.
    /// Team can be build of 1 or more Players.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface ITeam
    {
        /// <summary>
        /// Players assigned to this Team.
        /// </summary>
        IEnumerable<IPlayer> Players { get; }

        /// <summary>
        /// Number of rounds this Team has already won.
        /// </summary>
        int RoundsWon { get; }

        /// <summary>
        /// Adds new Player to the current Team.
        /// </summary>
        /// <param name="player"></param>
        void AddPlayer(IPlayer player);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class Team : ITeam
    {
        public IEnumerable<IPlayer> Players { get; } = new List<IPlayer>();
        public int RoundsWon { get; set; }

        public void AddPlayer(IPlayer player) =>
            ((List<IPlayer>) this.Players).Add(player);
    }
}