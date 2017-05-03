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
        /// <summary>
        /// Initializes a new instance of the <see cref="UserFind"/> class.
        /// </summary>
        /// <param name="adOperator">The Active Directory.</param>
        public UserFind(IADOperator adOperator) : base(adOperator){
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

        /// <summary>
        /// Finds all users in an organization unit.
        /// </summary>
        /// <param name="organizationalUnit">Distinguished name of OU.</param>
        /// <returns>List of UserObjects.</returns>
        public IList<UserObject> FindByOrganizationUnit(string organizationalUnit) {
            if (string.IsNullOrWhiteSpace(organizationalUnit)) {
                throw new ArgumentNullException(nameof(organizationalUnit));
            }
            return OrganizationalUnitObject.FindOneByOU(_adOperator, "Disabled Accounts").Users;
        }
    }
}
