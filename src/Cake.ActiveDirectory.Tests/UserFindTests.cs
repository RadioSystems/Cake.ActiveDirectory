using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.ActiveDirectory.Tests.Fixture;
using Landpy.ActiveDirectory.Core;
using Should;
using Should.Core.Assertions;

namespace Cake.ActiveDirectory.Tests {
    public sealed class UserFindTests {
        public void Should_Throw_If_ProxyAddress_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserFindFixture(adOperator);
            fixture.ProxyAddress = null;

            // When
            var result = Record.Exception(() => fixture.FindUserByProxyAddress());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("proxyAddress");
        }
    }
}
