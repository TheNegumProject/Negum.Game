namespace Negum.Game.Common.Network
{
    /// <summary>
    /// Responsible for handling packets.
    /// Contains methods for handling known packets on both sides.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IPacketHandler
    {
        /// <summary>
        /// Side-object with which the current packet handler is connected.
        /// </summary>
        INegumSide Side { get; }
    }
}