using System;
using Cake.ActiveDirectory.Users;
using Cake.Core;
using NSubstitute;
using Should;
using Should.Core.Assertions;

namespace Cake.ActiveDirectory.Tests {
    public sealed class AddUserAliasesTests {
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

        public void Should_Throw_If_samAccountName_Is_Null() {
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
        public void Should_Throw_If_Context_Is_Null()
        {
            // Given
            var attributeName = "test";
            var attributeValue = "test"; ;
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.UpdateUser(
                null, attributeName, attributeValue, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        public void Should_Throw_If_AttributeName_Is_Null()
        {
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

        public void Should_Throw_If_AttributeValue_Is_Null()
        {
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

        public void Should_Throw_If_Settings_Are_Null()
        {
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

    public sealed class DisableUserAliasesTests {
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
    }
}

