using System;
using System.Linq;
using System.Security;

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
    }
}
