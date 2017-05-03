using System;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Object;

namespace Cake.ActiveDirectory.Users {
    /// <summary>
    /// The User service for working with Active Directory Users
    /// </summary>
    public sealed class UserUpdate : ActiveDirectoryBase<UserSettings> {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserUpdate"/> class.
        /// </summary>
        /// <param name="adOperator">The Active Directory.</param>
        public UserUpdate(IADOperator adOperator) : base(adOperator) {
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
            if (string.IsNullOrWhiteSpace(attributeValue)) {
                throw new ArgumentNullException(nameof(attributeValue));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }

            var user = UserObject.FindAll(_adOperator, new Is(attributeName, attributeValue)).SingleOrDefault();
            if (user == null) {
                throw new ArgumentNullException($"Could not find user: {attributeValue}");
            }
            AddSettingsToUser(user, settings);
            user.Save();
        }

        /// <summary>
        /// Updates the Organizational Unit the user is in.
        /// </summary>
        /// <param name="propertyName">The name of the property to use to search.</param>
        /// <param name="propertyValue">The value of the property to search using.</param>
        /// <param name="organizationalUnit">The new organizational unit.</param>
        public void UpdateOrganizationUnit(string propertyName, string propertyValue, string organizationalUnit) {
            if (string.IsNullOrWhiteSpace(organizationalUnit)) {
                throw new ArgumentNullException(nameof(organizationalUnit));
            }
            var user = FindUser(propertyName, propertyValue);
            var orgUnit = OrganizationalUnitObject.FindOneByOU(_adOperator, organizationalUnit);
            if(orgUnit == null) {
                throw new ArgumentNullException(nameof(organizationalUnit), "OU was not found in Active Directory!");
            }
            user.ChangeOrganizationalUnit(orgUnit);
            user.Save();
        }
    }
}
