using Landpy.ActiveDirectory.Core;
using NSubstitute;
using System;
using Cake.ActiveDirectory.Tests.Fixture;
using Should;
using Xunit;

namespace Cake.ActiveDirectory.Tests {
    public sealed class UserDeleteTests {
        [Fact]
        public void Should_Throw_If_UserPrincipalName_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserDeleteFixture(adOperator);
            fixture.UserPrincipalName = null;

            // When
            var result = Record.Exception(() => fixture.DeleteUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("userPrincipalName");
        }
    }
}
