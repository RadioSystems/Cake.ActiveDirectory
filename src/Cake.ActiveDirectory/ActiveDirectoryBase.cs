using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Entity.Object;

namespace Cake.ActiveDirectory {
    /// <summary>
    /// The Active Directory command base class.
    /// </summary>
    public abstract class ActiveDirectoryBase<TSettings> where TSettings : ActiveDirectorySettings  {
        /// <summary>
        /// Adds user settings to the User Object.
        /// </summary>
        /// <param name="user">The user object to add settings.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>User object with new settings.</returns>
        protected UserObject AddSettingsToUser(UserObject user, UserSettings settings) {
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
            return user;
        }
    }
}
