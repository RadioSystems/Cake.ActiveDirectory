using Landpy.ActiveDirectory.Entity.Object;

namespace Cake.ActiveDirectory.Users {
    internal static class ExtensionMethods {
        public static void SetAttributeIfNotNull(this UserObject user, string attributeName, string attributeValue) {
            if (!string.IsNullOrWhiteSpace(attributeValue)) {
                user.SetAttributeValue(attributeName, attributeValue);
            }
        }
    }
}
