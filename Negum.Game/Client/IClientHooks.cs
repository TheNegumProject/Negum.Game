using System.Collections.Generic;

namespace Negum.Game.Client
{
    /// <summary>
    /// Represents a set of hooks which should be called from outside for interoperability.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IClientHooks : IClientModule
    {
        /// <summary>
        /// This hook allow outside code to indicate clicking operation.
        /// Multiple keys can be clicked "in the same time".
        /// </summary>
        /// <param name="keyCodes">Clicked keys.</param>
        void OnKeyPressed(IEnumerable<int> keyCodes);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ClientHooks : ClientModule, IClientHooks
    {
        public virtual void OnKeyPressed(IEnumerable<int> keyCodes) =>
            this.Client.Input.OnKeyPressed(keyCodes);
    }
}