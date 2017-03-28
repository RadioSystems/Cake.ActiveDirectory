# Cake.ActiveDirectory
Cake Addin for working with Active Directory.

[![License](http://img.shields.io/:license-apache-blue.svg)](https://github.com/RadioSystems/Cake.ActiveDirectory/blob/master/LICENSE)

## Information

| | Stable | Pre-release |
|---|---|---|
|GitHub Release|-|[![GitHub release](https://img.shields.io/github/release/Cake.ActiveDirectory/Cake.ActiveDirectory.svg)](https://github.com/RadioSystems/Cake.ActiveDirectory/releases/latest)|
|NuGet|[![NuGet](https://img.shields.io/nuget/v/Cake.ActiveDirectory.svg)](https://www.nuget.org/packages/Cake.ActiveDirectory)
|[![NuGet](https://img.shields.io/nuget/vpre/Cake.ActiveDirectory.svg)](https://www.nuget.org/packages/Cake.ActiveDirectory)|

## Build Status

[![beta-builds MyGet Build Status](https://www.myget.org/BuildSource/Badge/beta-builds?identifier=5e6a811d-5f15-431b-907f-086c980499c2)](https://www.myget.org/)
[![Build status](https://ci.appveyor.com/api/projects/status/pk0oc2np3atoqt4s?svg=true)](https://ci.appveyor.com/project/RadioSystems/cake-activedirectory)

## Code Coverage

[![Coverage Status](https://coveralls.io/repos/github/Cake.ActiveDirectory/Cake.ActiveDirectory/badge.svg?branch=develop)](https://coveralls.io/github/radiosystems/Cake.ActiveDirectory?branch=develop)

## Quick Links

- [Documentation](https://radiosystems.github.io/Cake.ActiveDirectory)

## Chat Room

Come join in the conversation about Cake.CsvHelper in our Gitter Chat Room

[![Join the chat at https://gitter.im/cake-contrib/Lobby](https://badges.gitter.im/cake-contrib/Lobby.svg)](https://gitter.im/cake-contrib/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Build

To build this package we are using Cake.

On Windows PowerShell run:

```powershell
./build
```

## About

This Addin only contains the functionality that we needed.  We are more than happy to accept pull requests that will grow this library.  It uses the [LandPy.ActiveDirectory](https://github.com/landpy/ActiveDirectoryLibrary) library for all Active Directory interaction.

## Usage

### Adding to your cake file

```
//Beta version
#addin nuget:https://www.myget.org/F/beta-builds/api/v2?package=Cake.ActiveDirectory 

// Release version
#addin nuget:?package=Cake.ActiveDirectory 
```

### Creating a user

```
CreateUser("cake-user", "cake-group", new UserSettings { 
    LoginName = "domainAdmin", 
    Password = "adminPassword", 
    DomainName = "Cake.net"});
```

### Updating a user

```
UpdateUser("employeeId", "1234", new UserSettings { 
    LoginName = "domainAdmin", 
    Password = "adminPassword", 
    DomainName = "Cake.net",
    Email = "test@cake-yeah.com" });
```

### Getting a user's UPN from their email address.

```
var upn = FindUserPrincipalNameByProperty("proxyAddresses", "jdoe@example.com", new UserSettings { 
            LoginName = "domainAdmin", 
            Password = "adminPassword", 
            DomainName = "Cake.net" });
```
