using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Galactic.ActiveDirectory;

namespace Cake.ActiveDirectory {
    /// <summary>
    /// The Active Directory service for working with directory objects.
    /// </summary>
    public sealed class ActiveDirectoryService : IActiveDirectoryService {
        private readonly Galactic.ActiveDirectory.ActiveDirectory _activeDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveDirectoryService"/> class.
        /// </summary>
        /// <param name="domainName">The AD domain.</param>
        /// <param name="userName">The AD serName.</param>
        /// <param name="password">The AD password.</param>
        public ActiveDirectoryService(string domainName, string userName, string password) {
            _activeDirectory = new Galactic.ActiveDirectory.ActiveDirectory(domainName, userName, password.ToSecureString());
        }

        /// <summary>
        /// Creates an Active Directory user given the specified properties.
        /// </summary>
        /// <param name="samAccountName">The SAM account name.</param>
        /// <param name="ouDistinguishedName">The OU distinguished name.</param>
        /// <param name="settings">The user attribute settings.</param>
        public void AddUser(string samAccountName, string ouDistinguishedName, UserAttributeSettings settings) {
            if (string.IsNullOrWhiteSpace(samAccountName)) {
                throw new ArgumentNullException(nameof(samAccountName));
            }
            if (string.IsNullOrWhiteSpace(ouDistinguishedName)) {
                throw new ArgumentNullException(nameof(ouDistinguishedName));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
            
            // Need to convert settings to Directory Attributes.

            User.Create(_activeDirectory, samAccountName, ouDistinguishedName);
        }

        /// <summary>
        /// Updates a user account given the specified properties.
        /// </summary>
        /// <param name="teammateId">The teammate id.</param>
        /// <param name="settings">The user attribute settings.</param>
        public void UpdateUser(string teammateId, UserAttributeSettings settings) {
            var user = new User(_activeDirectory, _activeDirectory.GetGUIDByEmployeeNumber(teammateId));
        }
    }
}
