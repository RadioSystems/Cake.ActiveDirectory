using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Tests.Fixture {
    internal sealed class UserUpdateFixture {
        private readonly UserUpdate _userUpdate;
        public UserSettings Settings { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

        public UserUpdateFixture(IADOperator adOperator) {
            _userUpdate = new UserUpdate(adOperator);
            AttributeName = "employeeId";
            AttributeValue = "1234";
            Settings = new UserSettings {LoginName = "admin", Password = "admin", DomainName = "test"};
        }

        public void UpdateUser() {
            _userUpdate.UpdateUser(AttributeName, AttributeValue, Settings);
        }
    }
}
