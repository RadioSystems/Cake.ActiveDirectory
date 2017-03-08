using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Tests.Fixture {
    internal sealed class UserFindFixture {
        private readonly UserFind _userFind;
        public UserSettings Settings { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        public UserFindFixture(IADOperator adOperator) {
            _userFind = new UserFind(adOperator);
            PropertyName = "proxyAddresses";
            PropertyValue = "jdoe@example.com";
            Settings = new UserSettings { LoginName = "admin", Password = "admin", DomainName = "test" };
        }

        public void FindUserPrincipalNameByProperty() {
            _userFind.FindUserPrincipalNameByProperty(PropertyName, PropertyValue);
        }
    }
}
