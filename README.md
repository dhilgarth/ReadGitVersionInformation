# ReadGitVersionInformation
Reads the version information injected by GitVersion.

# Usage
`ReadGitVersionInformation` can be added to your assembly and is then called like this:

```
var gitVersionInformation = GitVersion.GetVersionInformation();
```

`GetVersionInformation()` will return an instance of `IGitVersionInformation` with this signature:

```
public interface IGitVersionInformation
{
    VersionInformationType VersionInformationType { get; }
    string Major { get; }
    string Minor { get; }
    string Patch { get; }
    string PreReleaseTag { get; }
    string PreReleaseTagWithDash { get; }
    string PreReleaseLabel { get; }
    string PreReleaseNumber { get; }
    string BuildMetaData { get; }
    string BuildMetaDataPadded { get; }
    string FullBuildMetaData { get; }
    string MajorMinorPatch { get; }
    string SemVer { get; }
    string LegacySemVer { get; }
    string LegacySemVerPadded { get; }
    string AssemblySemVer { get; }
    string FullSemVer { get; }
    string InformationalVersion { get; }
    string BranchName { get; }
    string Sha { get; }
    string NuGetVersionV2 { get; }
    string NuGetVersion { get; }
    string CommitsSinceVersionSource { get; }
    string CommitsSinceVersionSourcePadded { get; }
    string CommitDate { get; }
}
```

`GetVersionInformation()` also has an overload that you can pass an assembly to. It will then provide the git version information for that assembly instead of the current one.

# Details
[GitVersion](https://github.com/GitTools/GitVersion) derives the current Semantic Version number from the Git repository.

This version can be added to the corresponding assemblies in two different ways:
- Using a [MS Build task](https://gitversion.readthedocs.io/en/latest/usage/msbuild-task/). This approach injects an internal class called `GitVersionInformation` into the assembly. This approach provides the most information.
- Using the [command line interface](https://gitversion.readthedocs.io/en/latest/usage/command-line/#inject-version-metadata-into-the-assembly) to inject the version into one or more `AssemblyVersion` files. This approach also provides a lot of information in form of the injected informational version string, however, not quite as much as the first approach.

If the git version information is injected into the assembly by the MS Build task, all data will be coming directly from the injected class and therefore, from GitVersion. `VersionInformationType` will be `FullGitVersionInformation`.  
If the git version information is injected into the assembly by the CLI, all data will be derived from the informational version string. Some information does not exist in this scenario, e.g. the `CommitDate`. This will return the string `0001-01-01`. Other properties for which no information can be derived simply return an empty string. Finally, some information might differ from what it would look like, if the MS Build task approach would have been used. `VersionInformationType` will be `DerivedGitVersionInformation`.  
If neither information exists, the library falls back to using the [`Version`](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assemblyname.version?view=netframework-4.7.2) of the assembly. In this case, many properties will either return an empty string or information that is far from the richness of the previous two approaches. `VersionInformationType` will be `AssemblyVersion`.  

# Contribution
If you see errors in deriving the information from the informational version string, please create an issue. As well as in all other cases where the library doesn't behave as expected.