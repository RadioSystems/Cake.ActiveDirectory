using NSubstitute;
using System;
using Cake.ActiveDirectory.Tests.Fixture;
using Landpy.ActiveDirectory.Core;
using Should;
using Should.Core.Assertions;

namespace Cake.ActiveDirectory.Tests {
    public sealed class UserFindTests {
        public void Should_Throw_If_PropertyName_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserFindFixture(adOperator);
            fixture.PropertyName = null;

            // When
            var result = Record.Exception(() => fixture.FindUserByProperty());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyName");
        }

        public void Should_Throw_If_PropertyValue_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserFindFixture(adOperator);
            fixture.PropertyValue = null;

            // When
            var result = Record.Exception(() => fixture.FindUserByProperty());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyValue");
        }
    }
}
