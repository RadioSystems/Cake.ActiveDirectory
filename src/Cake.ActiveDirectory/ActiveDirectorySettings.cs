namespace Cake.ActiveDirectory {
    /// <summary>
    /// The base class for all ActiveDirectory settings.
    /// </summary>
    public class ActiveDirectorySettings {
        /// <summary>
        /// LoginName for Active Directory Login
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// Password for Active Directory Login.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Active Directory domain name to operate on.
        /// </summary>
        public string DomainName { get; set; }
    }
}
