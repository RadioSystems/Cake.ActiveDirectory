using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Tests.Fixture {
    internal class UserDeleteFixture {
        private readonly UserDelete _userDelete;
        public string UserPrincipalName { get; set; }
        public UserSettings Settings { get; set; }

        public UserDeleteFixture(IADOperator adOperator) {
            _userDelete = new UserDelete(adOperator);
            UserPrincipalName = "test@test.com";
            Settings = new UserSettings { LoginName = "admin", Password = "admin", DomainName = "test" };
        }

        public void DeleteUser() {
            _userDelete.DeleteUser(UserPrincipalName);
        }
    }
}
