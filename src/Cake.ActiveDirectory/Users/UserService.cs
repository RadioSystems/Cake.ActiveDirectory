using System;
using Galactic.ActiveDirectory;

namespace Cake.ActiveDirectory.Users {
    /// <summary>
    /// The User service for working with Active Directory Users
    /// </summary>
    public sealed class UserService : ActiveDirectoryService<UserSettings> {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="domainName">The AD domain.</param>
        /// <param name="userName">The AD userName.</param>
        /// <param name="password">The AD password.</param>
        public UserService(string domainName, string userName, string password) : base(domainName, userName, password) {

        }

        /// <summary>
        /// Creates an Active Directory user given the specified properties.
        /// </summary>
        /// <param name="samAccountName">The SAM account name.</param>
        /// <param name="ouDistinguishedName">The OU distinguished name.</param>
        /// <param name="settings">The user attribute settings.</param>
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

            User.Create(CurrentActiveDirectory, samAccountName, ouDistinguishedName, settings.ToDirectoryAttributes());
        }

        /// <summary>
        /// Updates a user account given the specified properties.
        /// </summary>
        /// <param name="employeeId">The employee id.</param>
        /// <param name="settings">The user attribute settings.</param>
        public void UpdateUser(string employeeId, UserSettings settings) {
            if (string.IsNullOrWhiteSpace(employeeId)) {
                throw new ArgumentNullException(nameof(employeeId));
            }
            if (settings != null) {
                throw new ArgumentNullException(nameof(settings));
            }

            var user = new User(CurrentActiveDirectory, CurrentActiveDirectory.GetGUIDByEmployeeNumber(employeeId));

            if (!string.IsNullOrWhiteSpace(settings.FirstName)) {
                user.FirstName = settings.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(settings.LastName)) {
                user.LastName = settings.LastName;
            }

            if (!string.IsNullOrWhiteSpace(settings.DisplayName)) {
                user.DisplayName = settings.DisplayName;
            }

            if (!string.IsNullOrWhiteSpace(settings.Title)) {
                user.Title = settings.Title;
            }

            if (!string.IsNullOrWhiteSpace(settings.Manager)) {
                user.Manager = settings.Manager;
            }

            if (!string.IsNullOrWhiteSpace(settings.Department)) {
                user.Department = settings.Department;
            }

            if (!string.IsNullOrWhiteSpace(settings.Division)) {
                user.Division = settings.Division;
            }

            if (!string.IsNullOrWhiteSpace(settings.PhoneNumber)) {
                user.PhoneNumber = settings.PhoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(settings.StreetAddress)) {
                user.StreetAddress = settings.StreetAddress;
            }

            if (!string.IsNullOrWhiteSpace(settings.Description)) {
                user.Description = settings.Description;
            }

            if (!string.IsNullOrWhiteSpace(settings.EMailAddress)) {
                user.EMailAddress = settings.EMailAddress;
            }

            if (!string.IsNullOrWhiteSpace(settings.TargetAddress)) {
                user.TargetAddress = settings.TargetAddress;
            }

            if (!string.IsNullOrWhiteSpace(settings.HomeDirectory)) {
                user.HomeDirectory = settings.HomeDirectory;
            }

            if (!string.IsNullOrWhiteSpace(settings.HomeDrive)) {
                user.HomeDrive = settings.HomeDrive;
            }

            if (!string.IsNullOrWhiteSpace(settings.HomePage)) {
                user.HomePage = settings.HomePage;
            }
        }
    }
}
