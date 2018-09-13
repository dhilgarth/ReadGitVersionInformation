using System;
using System.Text.RegularExpressions;

namespace ReadGitVersionInformation
{
    internal class GitVersionInformationFromInformationalVersion : IGitVersionInformation
    {
        private static readonly Regex _regex = new Regex(
            @"^(?<Major>\d+)\.(?<Minor>\d+)\.(?<Patch>\d+)-(?<PreReleaseLabel>[^.]+)\.(?<PreReleaseNumber>\d+)\+Branch\.(?<BranchName>[^.]+)\.Sha\.(?<Sha>[0-9a-z]+)$");

        public GitVersionInformationFromInformationalVersion(string informationalVersion)
        {
            InformationalVersion = informationalVersion;
            var match = _regex.Match(informationalVersion);
            Major = match.Groups["Major"].Value;
            Minor = match.Groups["Minor"].Value;
            Patch = match.Groups["Patch"].Value;
            PreReleaseLabel = match.Groups["PreReleaseLabel"].Value;
            PreReleaseNumber = match.Groups["PreReleaseNumber"].Value;
            BranchName = match.Groups["BranchName"].Value;
            Sha = match.Groups["Sha"].Value;
        }

        public VersionInformationType VersionInformationType => VersionInformationType.DerivedGitVersionInformation;
        public string Major { get; }
        public string Minor { get; }
        public string Patch { get; }
        public string PreReleaseTag => $"{PreReleaseLabel}.{PreReleaseNumber}";
        public string PreReleaseTagWithDash => $"-{PreReleaseTag}";
        public string PreReleaseLabel { get; }
        public string PreReleaseNumber { get; }
        public string BuildMetaData => "";
        public string BuildMetaDataPadded => "";
        public string FullBuildMetaData => $"Branch.{BranchName}.Sha.{Sha}";
        public string MajorMinorPatch => $"{Major}.{Minor}.{Patch}";
        public string SemVer => $"{MajorMinorPatch}{PreReleaseTagWithDash}";
        public string LegacySemVer => $"{MajorMinorPatch}-{PreReleaseLabel}{PreReleaseNumber}";
        public string LegacySemVerPadded => $"{MajorMinorPatch}-{PreReleaseLabel}{CommitsSinceVersionSourcePadded}";
        public string AssemblySemVer => $"{MajorMinorPatch}.{PreReleaseNumber}";
        public string FullSemVer => SemVer;
        public string InformationalVersion { get; }
        public string BranchName { get; }
        public string Sha { get; }
        public string NuGetVersionV2 => LegacySemVerPadded;
        public string NuGetVersion => LegacySemVerPadded;
        public string CommitsSinceVersionSource => PreReleaseNumber;
        public string CommitsSinceVersionSourcePadded => $"{PreReleaseNumber.PadLeft(4, '0')}";
        public string CommitDate => new DateTime().ToString("yyyy-dd-MM");
        public static bool IsValidInformationalVersion(string informationalVersion) => _regex.IsMatch(informationalVersion);
    }
}