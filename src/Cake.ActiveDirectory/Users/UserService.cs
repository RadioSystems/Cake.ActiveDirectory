using System;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Object;

namespace Cake.ActiveDirectory.Users {
    /// <summary>
    /// The User service for working with Active Directory Users
    /// </summary>
    public sealed class UserService : ActiveDirectoryService<UserSettings> {
        private readonly IADOperator _adOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="adOperator">The Active Directory.</param>
        public UserService(IADOperator adOperator) {
            _adOperator = adOperator;
        }

        /// <summary>
        /// Creates an Active Directory user given the specified properties.
        /// </summary>
        /// <param name="samAccountName">The SAM account name.</param>
        /// <param name="ouDistinguishedName">The OU distinguished name.</param>
        /// <param name="settings">The user settings.</param>
        public void AddUser(string samAccountName, string ouDistinguishedName, UserSettings settings) {
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
            using (var user = organizationUnit.AddUser(samAccountName))
            {
                user.Save();
            }
        }

        /// <summary>
        /// Updates a user account given the specified properties.
        /// </summary>
        /// <param name="attributeName">The name of the attribute to search by.</param>
        /// <param name="attributeValue">The value of the attribute to search using.</param>
        /// <param name="settings">The user settings.</param>
        public void UpdateUser(string attributeName, string attributeValue, UserSettings settings) {
            if (string.IsNullOrWhiteSpace(attributeName)) {
                throw new ArgumentNullException(nameof(attributeName));
            }
            if (string.IsNullOrWhiteSpace(attributeValue))
            {
                throw new ArgumentNullException(nameof(attributeValue));
            }
            if (settings != null) {
                throw new ArgumentNullException(nameof(settings));
            }

            var user = UserObject.FindAll(_adOperator, new Is(attributeName, attributeValue)).SingleOrDefault();

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

            if (!string.IsNullOrWhiteSpace(settings.HomeDirectory)) {
                user.SetAttributeValue("homeDirectory", settings.HomeDirectory);
            }

            if (!string.IsNullOrWhiteSpace(settings.HomeDrive)) {
                user.SetAttributeValue("homeDrive", settings.HomeDrive);
            }

            user.IsMustChangePwdNextLogon = settings.MustChangePasswordNextLogon;
        }
    }
}
