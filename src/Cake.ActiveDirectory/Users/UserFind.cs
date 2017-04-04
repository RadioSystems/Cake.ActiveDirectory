using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Landpy.ActiveDirectory.Core;
using Landpy.ActiveDirectory.Core.Filter.Expression;
using Landpy.ActiveDirectory.Entity.Object;

namespace Cake.ActiveDirectory.Users {
    /// <summary>
    /// The User Find class for searching for Active Directory Users.
    /// </summary>
    public sealed class UserFind : ActiveDirectoryBase<UserSettings> {
        private readonly IADOperator _adOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserFind"/> class.
        /// </summary>
        /// <param name="adOperator">The Active Directory.</param>
        public UserFind(IADOperator adOperator) {
            _adOperator = adOperator;
        }

        /// <summary>
        /// Finds the User Principal Name by property.
        /// </summary>
        /// <param name="propertyName">The property to search against.</param>
        /// <param name="propertyValue">The property value to search.</param>
        /// <returns>User Principal Name</returns>
        public string FindUserPrincipalNameByProperty(string propertyName, string propertyValue) {
            return FindUser(propertyName, propertyValue)?.PrincipalName;
        }

        /// <summary>
        /// Finds the Distinguished Name by property.
        /// </summary>
        /// <param name="propertyName">The property to search against.</param>
        /// <param name="propertyValue">The property value to search.</param>
        /// <returns>Distinguished Name</returns>
        public string FindDistinguishedNameByProperty(string propertyName, string propertyValue) {
            return FindUser(propertyName, propertyValue)?.DistinguishedName;
        }

        /// <summary>
        /// Finds the attribute value by property.
        /// </summary>
        /// <param name="propertyName">The property to search against.</param>
        /// <param name="propertyValue">The property value to search.</param>
        /// <param name="attributeName">The attribute name of the value to get.</param>
        /// <returns>Attribute Value</returns>
        public string FindAttributeValueByProperty(string propertyName, string propertyValue, string attributeName) {
            if (string.IsNullOrWhiteSpace(attributeName)) {
                throw new ArgumentNullException(nameof(attributeName));
            }
            return FindUser(propertyName, propertyValue)?.GetAttributeValue<string>(attributeName);
        }

        private UserObject FindUser(string propertyName, string propertyValue) {
            if (string.IsNullOrWhiteSpace(propertyName)) {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (string.IsNullOrWhiteSpace(propertyValue)) {
                throw new ArgumentNullException(nameof(propertyValue));
            }
            return UserObject.FindAll(_adOperator, new Is(propertyName, propertyValue)).FirstOrDefault();
        }
    }
}
