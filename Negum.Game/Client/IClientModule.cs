namespace Negum.Game.Client
{
    /// <summary>
    /// Represents a module which can trigger a part of logic on client.
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public interface IClientModule
    {
        /// <summary>
        /// Client with which the current module is connected.
        /// </summary>
        INegumClient Client { get; }

        /// <summary>
        /// Initializes current module.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Initializes the module with given client object.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>Initialized module.</returns>
        IClientModule Use(INegumClient client);

        /// <summary>
        /// Performs single tick operation.
        /// </summary>
        /// <param name="deltaTime"></param>
        void Tick(double deltaTime);
    }

    /// <summary>
    /// </summary>
    /// 
    /// <author>
    /// https://github.com/TheNegumProject/Negum.Game
    /// </author>
    public abstract class ClientModule : IClientModule
    {
        /// <summary>
        /// Client to which the current module is connected.
        /// </summary>
        public INegumClient Client { get; private set; }

        /// <summary>
        /// By default we don't need to do anything.
        /// </summary>
        public virtual void Initialize()
        {
        }

        public IClientModule Use(INegumClient client)
        {
            this.Client = client;
            return this;
        }

        /// <summary>
        /// By default don't do anything.
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void Tick(double deltaTime)
        {
        }
    }
}