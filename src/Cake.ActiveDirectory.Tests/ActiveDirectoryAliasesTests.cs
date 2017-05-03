using System;
using Cake.ActiveDirectory.Users;
using Cake.Core;
using NSubstitute;
using Should;
using Xunit;

namespace Cake.ActiveDirectory.Tests {
    public sealed class AddUserAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var samAccountName = "test";
            var ouDistinguishedName = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.AddUser(
                null, samAccountName, ouDistinguishedName, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_SamAccountName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var ouDistinguishedName = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.AddUser(
                context, null, ouDistinguishedName, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("samAccountName");
        }

        [Fact]
        public void Should_Throw_If_OUDistinguishedName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var samAccountName = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.AddUser(
                context, samAccountName, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("ouDistinguishedName");
        }
    }

    public sealed class UpdateUserAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var attributeName = "test";
            var attributeValue = "test";
            ;
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.UpdateUser(
                null, attributeName, attributeValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_AttributeName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var attributeValue = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.UpdateUser(
                context, null, attributeValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("attributeName");
        }

        [Fact]
        public void Should_Throw_If_AttributeValue_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var attributeName = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.UpdateUser(
                context, attributeName, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("attributeValue");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var attributeName = "test";
            var attributeValue = "test";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.UpdateUser(
                context, attributeName, attributeValue, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }

    public sealed class FindUserPrincipalNameByProxyAddressAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var propertyName = "proxyAddresses";
            var propertyValue = "jdoe@example.com";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProperty(
                null, propertyName, propertyValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_PropertyName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyValue = "jdoe@example.com";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProperty(
                context, null, propertyValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyName");
        }

        [Fact]
        public void Should_Throw_If_PropertyValue_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "proxyAddresses";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProperty(
                context, propertyName, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyValue");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "proxyAddresses";
            var propertyValue = "jdoe@example.com";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProperty(
                context, propertyName, propertyValue, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }

    public sealed class FindDistinguishedNameByProxyAddressAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var propertyName = "proxyAddresses";
            var propertyValue = "jdoe@example.com";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindDistinguishedNameByProperty(
                null, propertyName, propertyValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_PropertyName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyValue = "jdoe@example.com";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindDistinguishedNameByProperty(
                context, null, propertyValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyName");
        }

        [Fact]
        public void Should_Throw_If_PropertyValue_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "proxyAddresses";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindDistinguishedNameByProperty(
                context, propertyName, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyValue");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "proxyAddresses";
            var propertyValue = "jdoe@example.com";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindDistinguishedNameByProperty(
                context, propertyName, propertyValue, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }

    public sealed class FindAttributeValueByProxyAddressAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var propertyName = "proxyAddresses";
            var propertyValue = "jdoe@example.com";
            var attributeName = "distinguishedName";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindAttributeValueByProperty(
                null, propertyName, propertyValue, attributeName, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_PropertyName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyValue = "jdoe@example.com";
            var attributeName = "distinguishedName";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindAttributeValueByProperty(
                context, null, propertyValue, attributeName, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyName");
        }

        [Fact]
        public void Should_Throw_If_PropertyValue_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "proxyAddresses";
            var attributeName = "distinguishedName";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindAttributeValueByProperty(
                context, propertyName, null, attributeName, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyValue");
        }

        [Fact]
        public void Should_Throw_If_AttributeName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "proxyAddresses";
            var propertyValue = "jdoe@example.com";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindAttributeValueByProperty(
                context, propertyName, propertyValue, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("attributeName");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "proxyAddresses";
            var propertyValue = "jdoe@example.com";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProperty(
                context, propertyName, propertyValue, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }

    public sealed class FindOrganizationalUnitAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var organizationalUnit = "Cake Users";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindByOrganizationUnit(
                null, organizationalUnit, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_OrganizationalUnit_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindByOrganizationUnit(
                context, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("organizationalUnit");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var organizationalUnit = "Cake Users";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindByOrganizationUnit(
                context, organizationalUnit, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }

    public sealed class DisableUserAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var propertyName = "test";
            var propertyvalue = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.DisableUser(
                null, propertyName, propertyvalue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_PropertyName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyValue = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.DisableUser(
                context, null, propertyValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyName");
        }

        [Fact]
        public void Should_Throw_If_PropertyValue_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var propertyName = "test";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.DisableUser(
                context, propertyName, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyValue");
        }

        public sealed class UpdateOrganizationUnitAliasesTests {
            [Fact]
            public void Should_Throw_If_Context_Is_Null() {
                // Given
                var propertyName = "test";
                var propertyValue = "test";
                ;
                var settings = new UserSettings();

                // When
                var result = Record.Exception(() => ActiveDirectoryAliases.UpdateUser(
                    null, propertyName, propertyValue, settings));

                // Then
                result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
            }

            [Fact]
            public void Should_Throw_If_AttributeName_Is_Null() {
                // Given
                var context = Substitute.For<ICakeContext>();
                var propertyValue = "test";
                var ou = "test";
                var settings = new UserSettings();

                // When
                var result = Record.Exception(() => ActiveDirectoryAliases.UpdateOrganizationUnit(
                    context, null, propertyValue, ou, settings));

                // Then
                result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyName");
            }

            [Fact]
            public void Should_Throw_If_PropertyValue_Is_Null() {
                // Given
                var context = Substitute.For<ICakeContext>();
                var propertyName = "test";
                var ou = "test";
                var settings = new UserSettings();

                // When
                var result = Record.Exception(() => ActiveDirectoryAliases.UpdateOrganizationUnit(
                    context, propertyName, null, ou, settings));

                // Then
                result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("propertyValue");
            }

            [Fact]
            public void Should_Throw_If_OrganizationalUnit_Is_Null() {
                // Given
                var context = Substitute.For<ICakeContext>();
                var propertyName = "test";
                var propertyValue = "test";
                var settings = new UserSettings();

                // When
                var result = Record.Exception(() => ActiveDirectoryAliases.UpdateOrganizationUnit(
                    context, propertyName, propertyValue, null, settings));

                // Then
                result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("organizationalUnit");
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null() {
                // Given
                var context = Substitute.For<ICakeContext>();
                var propertyName = "test";
                var propertyValue = "test";
                var ou = "test";

                // When
                var result = Record.Exception(() => ActiveDirectoryAliases.UpdateOrganizationUnit(
                    context, propertyName, propertyValue, ou, null));

                // Then
                result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
            }
        }
    }

    public sealed class DeleteUserAliasesTests {
        [Fact]
        public void Should_Throw_If_Context_Is_Null() {
            // Given
            var userPrincipalName = "test@test.com";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.DeleteUser(
                null, userPrincipalName, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        [Fact]
        public void Should_Throw_If_UserPrincipalName_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.DeleteUser(
                context, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("userPrincipalName");
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var userPrincipalName = "test@test.com";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.DeleteUser(
                context, userPrincipalName, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }
}