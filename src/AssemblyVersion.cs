using System;
using System.Reflection;

namespace Sovarto.ReadGitVersionInformation
{
    internal class AssemblyVersion : IGitVersionInformation
    {
        public AssemblyVersion(Assembly assembly)
        {
            var version = assembly.GetName().Version;
            Major = version.Major.ToString();
            Minor = version.Minor.ToString();
            Patch = version.Build.ToString();
            PreReleaseNumber = version.Revision.ToString();
        }

        public VersionInformationType VersionInformationType => VersionInformationType.AssemblyVersion;
        public string Major { get; }
        public string Minor { get; }
        public string Patch { get; }
        public string PreReleaseTag => "";
        public string PreReleaseTagWithDash => "";
        public string PreReleaseLabel => "";
        public string PreReleaseNumber { get; }
        public string BuildMetaData => "";
        public string BuildMetaDataPadded => "";
        public string FullBuildMetaData => SemVer;
        public string MajorMinorPatch => $"{Major}.{Minor}.{Patch}";
        public string SemVer => AssemblySemVer;
        public string LegacySemVer => SemVer;
        public string LegacySemVerPadded => $"{MajorMinorPatch}{PreReleaseTagWithDash}{CommitsSinceVersionSourcePadded}";
        public string AssemblySemVer => $"{MajorMinorPatch}.{PreReleaseNumber}";
        public string FullSemVer => SemVer;
        public string InformationalVersion => SemVer;
        public string BranchName => "";
        public string Sha => "";
        public string NuGetVersionV2 => LegacySemVerPadded;
        public string NuGetVersion => LegacySemVerPadded;
        public string CommitsSinceVersionSource => PreReleaseNumber;
        public string CommitsSinceVersionSourcePadded => $"{PreReleaseNumber.PadLeft(4, '0')}";
        public string CommitDate => new DateTime().ToString("yyyy-dd-MM");
    }
}