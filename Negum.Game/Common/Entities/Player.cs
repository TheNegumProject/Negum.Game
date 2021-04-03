using Negum.Core.Models.Characters;

namespace Negum.Game.Common.Entities
{
    /// <summary>
    /// Represents a single Player in current match.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class Player
    {
        /// <summary>
        /// Character which Player chose in select menu before the match started. 
        /// </summary>
        public ICharacter Character { get; set; }

        /// <summary>
        /// Total life points which Player has.
        /// </summary>
        public float LifePointsTotal { get; set; }

        /// <summary>
        /// Player's current life points.
        /// </summary>
        public float LifePoints { get; set; }

        /// <summary>
        /// Total power which Player has.
        /// </summary>
        public float PowerTotal { get; set; }

        /// <summary>
        /// PLayer's current power.
        /// </summary>
        public float Power { get; set; }
        
        // TODO: Add FacingDirection
        // TODO: Add CurrentState
        // TODO: Add Position
    }
}