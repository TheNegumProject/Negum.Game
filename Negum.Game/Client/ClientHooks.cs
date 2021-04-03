namespace Negum.Game.Client
{
    /// <summary>
    /// Represents a set of hooks which should be called from outside for interoperability.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public class ClientHooks
    {
        public INegumClient Client { get; }

        public ClientHooks(INegumClient client)
        {
            this.Client = client;
        }

        /// <summary>
        /// This hook allow outside code to indicate clicking operation.
        /// </summary>
        /// <param name="keyCode"></param>
        public virtual void OnKeyPressed(int keyCode) => 
            this.Client.Input.OnKeyPressed(keyCode);
    }
}