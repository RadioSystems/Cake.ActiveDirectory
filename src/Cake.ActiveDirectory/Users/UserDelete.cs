using System;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Users {
    /// <summary>
    /// The User delete class for deleting Active Directory users.
    /// </summary>
    public sealed class UserDelete : ActiveDirectoryBase<UserSettings> {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDelete"/> class.
        /// </summary>
        /// <param name="adOperator"></param>
        public UserDelete(IADOperator adOperator) : base(adOperator) { }

        /// <summary>
        /// Deletes user based on user principal name.
        /// </summary>
        /// <param name="userPrincipalName">User principal name.</param>
        public void DeleteUser(string userPrincipalName) {
            if (string.IsNullOrWhiteSpace(userPrincipalName)) {
                throw new ArgumentNullException(nameof(userPrincipalName));
            }
            var user = FindUser("userPrincipalName", userPrincipalName);
            if (user == null) {
                throw new ArgumentNullException($"Could not find user: {userPrincipalName}");
            }
            user.Delete();
        }
    }
}
