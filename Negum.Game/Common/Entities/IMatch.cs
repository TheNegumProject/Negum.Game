using System.Collections.Generic;
using System.Linq;

namespace Negum.Game.Common.Entities
{
    /// <summary>
    /// Represents a Match which will be played.
    /// In Match N teams takes part.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IMatch
    {
        /// <summary>
        /// Teams which takes part in this Match.
        /// </summary>
        IEnumerable<ITeam> Teams { get; }

        /// <summary>
        /// Total time limit for the single round in this Match.
        /// </summary>
        float TimeLimitTotal { get; }

        /// <summary>
        /// Left ticks in this round.
        /// </summary>
        float TimeLimit { get; }

        /// <summary>
        /// Total number of rounds to be played in this Match.
        /// </summary>
        int RoundsTotal { get; }

        /// <summary>
        /// Number of rounds not yet played.
        /// </summary>
        int RoundsLeft { get; }

        /// <summary>
        /// Adds Team to this Match.
        /// </summary>
        /// <param name="team"></param>
        void AddTeam(ITeam team);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class Match : IMatch
    {
        public IEnumerable<ITeam> Teams { get; } = new List<ITeam>();
        public float TimeLimitTotal { get; set; }
        public float TimeLimit { get; set; }
        public int RoundsTotal => this.Teams.Select(t => t.RoundsWon).Sum() + this.RoundsLeft;
        public int RoundsLeft { get; set; }

        public void AddTeam(ITeam team) =>
            ((List<ITeam>) this.Teams).Add(team);
    }
}