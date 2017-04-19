using Cake.ActiveDirectory.Tests.Fixture;
using Landpy.ActiveDirectory.Core;
using NSubstitute;
using Should;
using Should.Core.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake.ActiveDirectory.Tests {
    public sealed class UserDisableTests {
        public void Should_Throw_If_AttributeName_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserDisableFixture(adOperator);
            fixture.PropertyName = null;

            // When
            var result = Record.Exception(() => fixture.DisableUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyName");
        }

        public void Should_Throw_If_AttributeValue_Is_Null() {
            // Given
            var adOperator = Substitute.For<IADOperator>();
            var fixture = new UserDisableFixture(adOperator);
            fixture.PropertyValue = null;

            // When
            var result = Record.Exception(() => fixture.DisableUser());

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyValue");
        }
    }
}
