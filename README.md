# Cake.ActiveDirectory
Cake Addin for working with Active Directory.

[![beta-builds MyGet Build Status](https://www.myget.org/BuildSource/Badge/beta-builds?identifier=5e6a811d-5f15-431b-907f-086c980499c2)](https://www.myget.org/)
[![Build status](https://ci.appveyor.com/api/projects/status/pk0oc2np3atoqt4s?svg=true)](https://ci.appveyor.com/project/RadioSystems/cake-activedirectory)

## About

This Addin only contains the functionality that we needed.  We are more than happy to accept pull requests that will grow this library.  It uses the [LandPy.ActiveDirectory](https://github.com/landpy/ActiveDirectoryLibrary) library for all Active Directory interaction.

## Usage

### Adding to your cake file

```
//Beta version
#addin nuget:https://www.myget.org/F/beta-builds/api/v2?package=Cake.ActiveDirectory 

// Release version
#addin nuget?package=Cake.ActiveDirectory
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
