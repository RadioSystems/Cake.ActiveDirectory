using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Security;
using Cake.ActiveDirectory.Users;
using Galactic.ActiveDirectory;

namespace Cake.ActiveDirectory {
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class ExtensionMethods {
        /// <summary>
        /// Converts a string to a secure readonly string.
        /// </summary>
        /// <returns>SecureString</returns>
        public static SecureString ToSecureString(this string str) {
            var secureString = new SecureString();
            Array.ForEach(str.ToArray(), secureString.AppendChar);
            secureString.MakeReadOnly();
            return secureString;
        }

        /// <summary>
        /// Returns a list of Directory Attributes based on properties in settings.
        /// </summary>
        /// <param name="settings">The User Attribute Settings.</param>
        /// <returns>List of Directory Attributes.</returns>
        public static List<DirectoryAttribute> ToDirectoryAttributes(this UserSettings settings) {
            return
                settings.GetType().GetProperties().Select(x => new DirectoryAttribute(x.Name, x.GetValue(x).ToString())).ToList();
        }
    }
}
