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
    public class Team
    {
        /// <summary>
        /// Players assigned to this Team.
        /// </summary>
        public ICollection<Player> Players { get; } = new List<Player>();

        /// <summary>
        /// Number of rounds this Team has already won.
        /// </summary>
        public int RoundsWon { get; set; }
    }
}