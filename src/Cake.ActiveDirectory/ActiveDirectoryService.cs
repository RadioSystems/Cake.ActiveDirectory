namespace Cake.ActiveDirectory {
    /// <summary>
    /// The Active Directory service for working with directory objects.
    /// </summary>
    public abstract class ActiveDirectoryService<TSettings> where TSettings : ActiveDirectorySettings  {
        private readonly Galactic.ActiveDirectory.ActiveDirectory _activeActiveDirectory;

        /// <summary>
        /// Base class constructor.
        /// </summary>
        /// <param name="domainName">The AD domain.</param>
        /// <param name="userName">The AD userName.</param>
        /// <param name="password">The AD password.</param>
        protected ActiveDirectoryService(string domainName, string userName, string password) {
            _activeActiveDirectory = new Galactic.ActiveDirectory.ActiveDirectory(domainName, userName, password.ToSecureString());
        }

        /// <summary>
        /// Gets the Current Active Directory.
        /// </summary>
        protected Galactic.ActiveDirectory.ActiveDirectory CurrentActiveDirectory => _activeActiveDirectory;
    }
}
