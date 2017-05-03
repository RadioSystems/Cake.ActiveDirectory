using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Tests.Fixture {
    internal sealed class UserDisableFixture {
        private readonly UserDisable _userDisable;
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        public UserDisableFixture(IADOperator adOperator) {
            _userDisable = new UserDisable(adOperator);
            PropertyName = "proxyAddresses";
            PropertyValue = "jdoe@example.com";
        }

        public void DisableUser() {
            _userDisable.DisableUser(PropertyName, PropertyValue);
        }
    }
}
