namespace Sovarto.ReadGitVersionInformation
{
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
}