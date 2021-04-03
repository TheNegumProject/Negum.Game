using System.Collections.Generic;
using Negum.Core.Models.Stages;

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
    public class Match
    {
        /// <summary>
        /// Currently played Stage.
        /// </summary>
        public IStage Stage { get; set; }
        
        /// <summary>
        /// Teams which takes part in this Match.
        /// </summary>
        public ICollection<Team> Teams { get; } = new List<Team>();

        /// <summary>
        /// Total time limit for the single round in this Match.
        /// </summary>
        public float TimeLimitTotal { get; set; }

        /// <summary>
        /// Left ticks in this round.
        /// </summary>
        public float TimeLimit { get; set; }

        /// <summary>
        /// Total number of rounds to be played in this Match.
        /// </summary>
        public int RoundsTotal { get; set; }

        /// <summary>
        /// Number of rounds not yet played.
        /// </summary>
        public int RoundsLeft { get; set; }
    }
}