using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Tests.Fixture {
    internal sealed class UserFindFixture {
        private readonly UserFind _userFind;
        public UserSettings Settings { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string AttributeName { get; set; }

        public UserFindFixture(IADOperator adOperator) {
            _userFind = new UserFind(adOperator);
            PropertyName = "proxyAddresses";
            PropertyValue = "jdoe@example.com";
            AttributeName = "distinguishedName";
            Settings = new UserSettings { LoginName = "admin", Password = "admin", DomainName = "test" };
        }

        public void FindUserPrincipalNameByProperty() {
            _userFind.FindUserPrincipalNameByProperty(PropertyName, PropertyValue);
        }

        public void FindDistinguishedNameByProperty() {
            _userFind.FindUserPrincipalNameByProperty(PropertyName, PropertyValue);
        }

        public void FindAttributeValueByProperty() {
            _userFind.FindAttributeValueByProperty(PropertyName, PropertyValue, AttributeName);
        }
    }
}
