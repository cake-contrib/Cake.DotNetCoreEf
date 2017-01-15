# Cake.DotNetCoreEf

Cake.DotNetCoreEf is an Addin that extends [Cake](http://cakebuild.net/) for executing commands with the dotnet ef command line interface (CLI). To use this addin the dotnet CLI must be installed [DotNet CLI](https://www.microsoft.com/net/core#windowscmd).

## Build status 

[![Build status](https://ci.appveyor.com/api/projects/status/fyk64dwsp69pis7i?retina=true)](https://ci.appveyor.com/project/cakecontrib/cake-dotnetcoreef)

## Referencing

You can reference Cake.DotNetCoreEf in your build script as a cake addin:
```cake
#addin "Cake.DotNetCoreEf"
```  

or nuget reference:

```cake
#addin "nuget:https://www.nuget.org/api/v2?package=Cake.DotNetCoreEf"
```

## Contribution GuideLines

[https://github.com/cake-build/cake/blob/develop/CONTRIBUTING.md](https://github.com/cake-build/cake/blob/develop/CONTRIBUTING.md)

## License

Copyright (c) 2017 Cake Contributions Organization  

Cake.DotNetCoreEf is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/cake-contrib/Cake.DotNetCoreEf/blob/master/LICENSE).
