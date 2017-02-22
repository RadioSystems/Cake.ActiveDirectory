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
        /// Gets the User Principal Name by proxy address.
        /// </summary>
        /// <param name="proxyAddress">The proxy address value to search.</param>
        /// <returns>User Principal Name</returns>
        public string GetUserPrincipalNameFromProxyAddress(string proxyAddress) {
            if (string.IsNullOrWhiteSpace(proxyAddress)) {
                throw new ArgumentNullException(nameof(proxyAddress));
            }
            return UserObject.FindAll(_adOperator, new Contains("proxyAddresses", proxyAddress)).FirstOrDefault()?.PrincipalName;
        }
    }
}
