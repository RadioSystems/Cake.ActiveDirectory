using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Tests.Fixture {
    internal sealed class UserCreateFixture {
        private readonly UserCreate _userCreate;
        public UserSettings Settings { get; set; }
        public string SamAccountName { get; set; }
        public string OuDistinguishedName { get; set; }

        public UserCreateFixture(IADOperator adOperator) {
            _userCreate = new UserCreate(adOperator);
            SamAccountName = "test";
            OuDistinguishedName = "group";
            Settings = new UserSettings {LoginName = "admin", Password = "admin", DomainName = "test"};
        }

        public void CreateUser() {
            _userCreate.CreateUser(SamAccountName, OuDistinguishedName, Settings);
        }
    }
}
