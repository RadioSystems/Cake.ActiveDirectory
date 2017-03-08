using System;
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
        public string FindUserByProperty(string propertyName, string propertyValue) {
            if (string.IsNullOrWhiteSpace(propertyName)) {
                throw new ArgumentNullException(nameof(propertyName));
            }
            if (string.IsNullOrWhiteSpace(propertyValue)) {
                throw new ArgumentNullException(nameof(propertyValue));
            }
            return UserObject.FindAll(_adOperator, new Contains(propertyName, propertyValue)).FirstOrDefault()?.PrincipalName;
        }
    }
}
