using System.Collections.Generic;

namespace Cake.ActiveDirectory.Users {
    /// <summary>
    /// Contains settings used by <see cref="UserService"/>.
    /// </summary>
    public class UserSettings : ActiveDirectorySettings {
        /// <summary>
        /// Gets or sets the Employee Id.
        /// </summary>
        public string EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the Employee Number.
        /// </summary>
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// Gets or set the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the display name of the user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the title of the user.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the manager of the user.
        /// </summary>
        public string Manager { get; set; }

        /// <summary>
        /// Gets or sets the deparment of the user.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// The user's division in the organization.
        /// </summary>
        public string Division { get; set; }

        /// <summary>
        /// The user's telephone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The user's street address.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// A description of the user.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        public string EMailAddress { get; set; }

        /// <summary>
        /// The user's target email address.
        /// </summary>
        public string TargetAddress { get; set; }

        /// <summary>
        /// The path to the user's home directory.
        /// </summary>
        public string HomeDirectory { get; set; }

        /// <summary>
        /// The user's home drive letter.
        /// </summary>
        public string HomeDrive { get; set; }

        /// <summary>
        /// The user's home page URL.
        /// </summary>
        public string HomePage { get; set; }

        /// <summary>
        /// Gets or sets if password needs changed on next logon.
        /// </summary>
        public bool MustChangePasswordNextLogon { get; set; }
    }
}
