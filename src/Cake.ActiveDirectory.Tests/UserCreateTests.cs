using System;
using System.Linq;
using Cake.ActiveDirectory.Tests.Fixture;
using Landpy.ActiveDirectory.Core;
using NSubstitute;
using Should;
using Should.Core.Assertions;

namespace Cake.ActiveDirectory.Tests {
    public sealed class UserCreateTests {
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserCreateFixture(adOperator);
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => fixture.CreateUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }

        public void Should_Throw_If_SAMAccountName_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserCreateFixture(adOperator);
            fixture.SamAccountName = null;

            // When
            var result = Record.Exception(() => fixture.CreateUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("samAccountName");
        }

        public void Should_Throw_If_OUDistinguishedName_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserCreateFixture(adOperator);
            fixture.OuDistinguishedName = null;

            // When
            var result = Record.Exception(() => fixture.CreateUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("ouDistinguishedName");
        }

        public void Should_Create_User() {
            //Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserCreateFixture(adOperator);

            // When
            //fixture.CreateUser();

            // Then
        }
    }
}
