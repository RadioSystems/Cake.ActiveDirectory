using System;
using Cake.ActiveDirectory.Users;
using Cake.Core;
using Cake.Core.Annotations;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory {
    /// <summary>
    /// Contains functionality related to managing Active Directory.
    /// </summary>
    [CakeAliasCategory("ActiveDirectory")]
    public static class ActiveDirectoryAliases {
        /// <summary>
        /// Creates a new user in the specified active directory.
        /// </summary>
        /// <example>
        /// <code>
        ///     CreateUser("cake-user", "cake-group", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net"});
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="samAccountName">The SAM account name of new user.</param>
        /// <param name="ouDistinguishedName">The distinguished name of the OU.</param>
        /// <param name="settings">The user settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CreateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void AddUser(this ICakeContext context, string samAccountName, string ouDistinguishedName,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
           
            var userCreate = new UserCreate(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            userCreate.CreateUser(samAccountName, ouDistinguishedName, settings);
        }

        /// <summary>
        /// Updates a user account given the specified properties.
        /// </summary>
        /// <example>
        /// <code>
        ///     UpdateUser("employeeId", "1234", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net",
        ///         Email = "test@cake-yeah.com" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="attributeName">The name of the attribute to search by.</param>
        /// <param name="attributeValue">The value of the attribute to search using.</param>
        /// <param name="settings">The user attribute settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("UpdateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void UpdateUser(this ICakeContext context, string attributeName, string attributeValue,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            var userUpdate = CreateUserUpdate(settings);
            userUpdate.UpdateUser(attributeName, attributeValue, settings);
        }

        /// <summary>
        /// Finds User Principal Name by Property Value.
        /// </summary>
        /// <example>
        /// <code>
        ///     var upn = FindUserPrincipalNameByProperty("proxyAddresses", "jdoe@example.com", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="propertyName">The property name to search against.</param>
        /// <param name="propertyValue">The property value to search.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>User Principal Name</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("FindUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static string FindUserPrincipalNameByProperty(this ICakeContext context, string propertyName, string propertyValue, UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            var userFind = CreateUserFind(settings);
            return userFind.FindUserPrincipalNameByProperty(propertyName, propertyValue);
        }

        private static UserFind CreateUserFind(UserSettings settings) {
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
            return new UserFind(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
        }

        /// <summary>
        /// Finds Distinguished Name by Property Value.
        /// </summary>
        /// <example>
        /// <code>
        ///     var distinguishedName = FindDistinguishedNameByProperty("proxyAddresses", "jdoe@example.com", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="propertyName">The property name to search against.</param>
        /// <param name="propertyValue">The property value to search.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Distinguished Name</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("FindUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static string FindDistinguishedNameByProperty(this ICakeContext context, string propertyName, string propertyValue, UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            var userFind = CreateUserFind(settings);
            return userFind.FindDistinguishedNameByProperty(propertyName, propertyValue);
        }

        /// <summary>
        /// Finds attribute value by Property Value.
        /// </summary>
        /// <example>
        /// <code>
        ///     var distinguishedName = FindDistinguishedNameByProperty("proxyAddresses", "jdoe@example.com", "distinguishedName", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="propertyName">The property name to search against.</param>
        /// <param name="propertyValue">The property value to search.</param>
        /// <param name="attributeName">The attribute name of the value to get.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>Attribute value.</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("FindUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static string FindAttributeValueByProperty(this ICakeContext context, string propertyName, string propertyValue, string attributeName, UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            var userFind = CreateUserFind(settings);
            return userFind.FindAttributeValueByProperty(propertyName, propertyValue, attributeName);
        }

        /// <summary>
        /// Disables a user account given the specified properties.
        /// </summary>
        /// <example>
        /// <code>
        ///     DisableUser("employeeId", "1234", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="propertyName">The name of the property to search by.</param>
        /// <param name="propertyValue">The value of the property to search using.</param>
        /// <param name="settings">The user attribute settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("UpdateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void DisableUser(this ICakeContext context, string propertyName, string propertyValue,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }

            var userDisable = new UserDisable(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            userDisable.DisableUser(propertyName, propertyValue);
        }

        /// <summary>
        /// Updates a user's oraganization unit, given the specified properties.
        /// </summary>
        /// <example>
        /// <code>
        ///     UpdateOrganizationUnit("employeeId", "1234", "test", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="propertyName">The name of the property to search by.</param>
        /// <param name="propertyValue">The value of the property to search using.</param>
        /// <param name="organizationalUnit">The new organizational unit.</param>
        /// <param name="settings">The user attribute settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("UpdateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void UpdateOrganizationUnit(this ICakeContext context, string propertyName, string propertyValue, string organizationalUnit,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            var userUpdate = CreateUserUpdate(settings);
            userUpdate.UpdateOrganizationUnit(propertyName, propertyValue, organizationalUnit);
        }

        private static UserUpdate CreateUserUpdate(UserSettings settings) {
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
            return new UserUpdate(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
        }

        /// <summary>
        /// Creates a new user in the specified active directory.
        /// </summary>
        /// <example>
        /// <code>
        ///     DeleteUser("cake-user@cake.net", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net"});
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="userPrincipalName">The user principal name.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("CreateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void DeleteUser(this ICakeContext context, string userPrincipalName, 
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
            var userDelete = new UserDelete(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            userDelete.DeleteUser(userPrincipalName);
        }
    }
}
