# OrleansHelloWorldSample.Core
Orleans HelloWorld sample targeting .NET Core

Just build the nuget packages for Orleans 2.0 by getting the latest from master and then from the commandline run:

`Build.cmd netstandard`

This will create NuGet packages in the following folder: `<orleansroot>/vNext/Binaries/Debug`

Then you can open the sample, and add a NuGet feed pointing to the nuget package output folder.
Restore the packages in the solution.
Build.
Run the SiloHost and the OrleansClient projects in .NET Core.
