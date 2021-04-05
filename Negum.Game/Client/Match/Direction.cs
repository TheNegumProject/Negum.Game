namespace Negum.Game.Client.Match
{
    /// <summary>
    /// Possible direction in the game.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class Direction
    {
        public static Direction Up { get; } = new Direction("U");
        public static Direction Down { get; } = new Direction("D");
        public static Direction Forward { get; } = new Direction("F");
        public static Direction Backward { get; } = new Direction("B");

        /// <summary>
        /// Represents current direction in string format.
        /// Used mainly in handling commands.
        /// </summary>
        public string Character { get; }

        private Direction(string character)
        {
            this.Character = character;
        }
    }
}