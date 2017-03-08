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
        private readonly IADOperator _adOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserUpdate"/> class.
        /// </summary>
        /// <param name="adOperator">The Active Directory.</param>
        public UserUpdate(IADOperator adOperator) {
            _adOperator = adOperator;
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
        }
    }
}
