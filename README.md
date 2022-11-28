[![NuGet package](https://img.shields.io/nuget/v/LargeAddressAware.svg)](https://nuget.org/packages/LargeAddressAware)

# LargeAddressAware
A build tools package that adds support for making 32-bit exes LARGEADDRESSAWARE.

Note: if your .exe is AnyCPU (32-bit preferred or not), then you don't need this tool. These are large address aware already. This tool is strictly for .exes targeting x86 specifically.

To use, install the NuGet package and set this property in your .csproj file:

```
  <PropertyGroup>
    <LargeAddressAware>true</LargeAddressAware>
  </PropertyGroup>
```

Also make sure that the .targets file from the NuPkg is included in your build. To do this, build your project using http://msbuildlog.com and search for `$target SetLargeAddressAware` in the structured log.

You can customize after which target the SetLargeAddressAware target runs by setting this property:

```
  <PropertyGroup>
    <LargeAddressAwareAfterTargets>MyCustomTarget</LargeAddressAwareAfterTargets>
  </PropertyGroup>
```

By default it runs after CoreCompile.

You can also customize which target assembly should be modified by setting this property:

```
  <PropertyGroup>
    <LargeAddressAwareTargetAssembly>bin/$(Configuration)/$(AssemblyName).exe</LargeAddressAwareTargetAssembly>
    <LargeAddressAwareAfterTargets>AfterBuild</LargeAddressAwareAfterTargets>
  </PropertyGroup>
```

This is required in order to set the LargeAddressAware flag to .Net Core executables as otherwise the flag will be set to the application dll. Please note that the ``LargeAddressAwareAfterTargets`` setting must be set to a later build stage such as ``AfterBuild``.
