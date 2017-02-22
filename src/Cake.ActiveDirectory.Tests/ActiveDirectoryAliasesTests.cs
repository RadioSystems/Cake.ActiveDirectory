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

        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var samAccountName = "test";
            var ouDistinguishedName = "test";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.AddUser(
                context, samAccountName, ouDistinguishedName, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
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
            var proxyAddress = "jdoe@example.com";
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProxyAddress(
                null, proxyAddress, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("context");
        }

        public void Should_Throw_If_ProxyAddress_Is_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var settings = new UserSettings();

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProxyAddress(
              context, null, settings));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("proxyAddress");
        }
        
        public void Should_Throw_If_Settings_Are_Null() {
            // Given
            var context = Substitute.For<ICakeContext>();
            var proxyAddress = "jdoe@example.com";

            // When
            var result = Record.Exception(() => ActiveDirectoryAliases.FindUserPrincipalNameByProxyAddress(
                context, proxyAddress, null));

            // Then
            result.ShouldBeType<ArgumentNullException>().ParamName.ShouldEqual("settings");
        }
    }
}

