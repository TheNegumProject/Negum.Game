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
    public interface IPlayer
    {
        /// <summary>
        /// Character which Player chose in select menu before the match started. 
        /// </summary>
        ICharacter Character { get; }

        /// <summary>
        /// Total life points which Player has.
        /// </summary>
        float LifePointsTotal { get; }

        /// <summary>
        /// Player's current life points.
        /// </summary>
        float LifePoints { get; }

        /// <summary>
        /// Total power which Player has.
        /// </summary>
        float PowerTotal { get; }

        /// <summary>
        /// PLayer's current power.
        /// </summary>
        float Power { get; }
    }
    
    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class Player : IPlayer
    {
        public ICharacter Character { get; set; }
        public float LifePointsTotal { get; set; }
        public float LifePoints { get; set; }
        public float PowerTotal { get; set; }
        public float Power { get; set; }
    }
}