using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.ActiveDirectory.Users;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory.Tests.Fixture {
    internal sealed class UserFindFixture {
        private readonly UserFind _userFind;
        public UserSettings Settings { get; set; }
        public string ProxyAddress { get; set; }

        public UserFindFixture(IADOperator adOperator) {
            _userFind = new UserFind(adOperator);
            ProxyAddress = "jdoe@example.com";
            Settings = new UserSettings { LoginName = "admin", Password = "admin", DomainName = "test" };
        }

        public void FindUserByProxyAddress() {
            _userFind.GetUserPrincipalNameFromProxyAddress(ProxyAddress);
        }
    }
}
