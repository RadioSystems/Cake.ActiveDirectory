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
                if (!string.IsNullOrWhiteSpace(settings.FirstName)) {
                    user.GivenName = settings.FirstName;
                }

                if (!string.IsNullOrWhiteSpace(settings.LastName)) {
                    user.LastName = settings.LastName;
                }

                if (!string.IsNullOrWhiteSpace(settings.DisplayName)) {
                    user.DisplayName = settings.DisplayName;
                }

                if (!string.IsNullOrWhiteSpace(settings.Title)) {
                    user.JobTitle = settings.Title;
                }

                if (!string.IsNullOrWhiteSpace(settings.Manager)) {
                    user.Manager = settings.Manager;
                }

                if (!string.IsNullOrWhiteSpace(settings.Department)) {
                    user.Department = settings.Department;
                }

                if (!string.IsNullOrWhiteSpace(settings.PhoneNumber)) {
                    user.Telephone = settings.PhoneNumber;
                }

                if (!string.IsNullOrWhiteSpace(settings.StreetAddress)) {
                    user.StreetAddress = settings.StreetAddress;
                }

                if (!string.IsNullOrWhiteSpace(settings.Description)) {
                    user.Description = settings.Description;
                }

                if (!string.IsNullOrWhiteSpace(settings.Email)) {
                    user.Email = settings.Email;
                }
                user.SetAttributeIfNotNull("homeDirectory", settings.HomeDirectory);
                user.SetAttributeIfNotNull("homeDrive", settings.HomeDrive);
                user.IsMustChangePwdNextLogon = settings.MustChangePasswordNextLogon;
                user.Save();
            }
        }
    }
}
