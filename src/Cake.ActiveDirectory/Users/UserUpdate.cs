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

            AddSettingsToUser(user, settings);

            user.Save();
        }
    }
}
