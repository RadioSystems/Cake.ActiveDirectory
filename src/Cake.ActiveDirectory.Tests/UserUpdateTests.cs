using System;
using Cake.ActiveDirectory.Tests.Fixture;
using Landpy.ActiveDirectory.Core;
using NSubstitute;
using Should;
using Should.Core.Assertions;

namespace Cake.ActiveDirectory.Tests
{
    public sealed class UserUpdateTests
    {
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserUpdateFixture(adOperator);
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => fixture.UpdateUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }

        public void Should_Throw_If_AttributeName_Is_Null()
        {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserUpdateFixture(adOperator);
            fixture.AttributeName = null;

            // When
            var result = Record.Exception(() => fixture.UpdateUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("attributeName");
        }

        public void Should_Throw_If_AttributeValue_Is_Null()
        {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserUpdateFixture(adOperator);
            fixture.AttributeValue = null;

            // When
            var result = Record.Exception(() => fixture.UpdateUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("attributeValue");
        }
    }
}
