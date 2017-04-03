using System;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Entity.Object;

namespace Cake.ActiveDirectory.Users {
    /// <summary>
    /// The User create class for creating Active Directory Users.
    /// </summary>
    public sealed class UserCreate : ActiveDirectoryBase<UserSettings> {
        private readonly IADOperator _adOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCreate"/> class.
        /// </summary>
        /// <param name="adOperator">The Active Directory.</param>
        public UserCreate(IADOperator adOperator) {
            _adOperator = adOperator;
        }

        /// <summary>
        /// Creates an Active Directory user given the specified properties.
        /// </summary>
        /// <param name="samAccountName">The SAM account name.</param>
        /// <param name="ouDistinguishedName">The OU distinguished name.</param>
        /// <param name="settings">The user settings.</param>
        public void CreateUser(string samAccountName, string ouDistinguishedName, UserSettings settings) {
            if (string.IsNullOrWhiteSpace(samAccountName)) {
                throw new ArgumentNullException(nameof(samAccountName));
            }
            if (string.IsNullOrWhiteSpace(ouDistinguishedName)) {
                throw new ArgumentNullException(nameof(ouDistinguishedName));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
            using (var organizationUnit = OrganizationalUnitObject.FindOneByDN(_adOperator, ouDistinguishedName))
            using (var user = organizationUnit.AddUser(samAccountName)) {
                AddSettingsToUser(user, settings);

                user.Save();
            }
        }
    }
}
