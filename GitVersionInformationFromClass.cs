using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReadGitVersionInformation
{
    internal class GitVersionInformationFromClass : IGitVersionInformation
    {
        private readonly Dictionary<string, string> _values;

        public GitVersionInformationFromClass(IEnumerable<FieldInfo> fields)
        {
            if (fields == null)
                throw new ArgumentNullException(nameof(fields));
            _values = fields.ToDictionary(x => x.Name, x => (string)x.GetValue(null));
        }

        public VersionInformationType VersionInformationType => VersionInformationType.FullGitVersionInformation;
        public string Major => GetFieldValue("Major");
        public string Minor => GetFieldValue("Minor");
        public string Patch => GetFieldValue("Patch");
        public string PreReleaseTag => GetFieldValue("PreReleaseTag");
        public string PreReleaseTagWithDash => GetFieldValue("PreReleaseTagWithDash");
        public string PreReleaseLabel => GetFieldValue("PreReleaseLabel");
        public string PreReleaseNumber => GetFieldValue("PreReleaseNumber");
        public string BuildMetaData => GetFieldValue("BuildMetaData");
        public string BuildMetaDataPadded => GetFieldValue("BuildMetaDataPadded");
        public string FullBuildMetaData => GetFieldValue("FullBuildMetaData");
        public string MajorMinorPatch => GetFieldValue("MajorMinorPatch");
        public string SemVer => GetFieldValue("SemVer");
        public string LegacySemVer => GetFieldValue("LegacySemVer");
        public string LegacySemVerPadded => GetFieldValue("LegacySemVerPadded");
        public string AssemblySemVer => GetFieldValue("AssemblySemVer");
        public string FullSemVer => GetFieldValue("FullSemVer");
        public string InformationalVersion => GetFieldValue("InformationalVersion");
        public string BranchName => GetFieldValue("BranchName");
        public string Sha => GetFieldValue("Sha");
        public string NuGetVersionV2 => GetFieldValue("NuGetVersionV2");
        public string NuGetVersion => GetFieldValue("NuGetVersion");
        public string CommitsSinceVersionSource => GetFieldValue("CommitsSinceVersionSource");
        public string CommitsSinceVersionSourcePadded => GetFieldValue("CommitsSinceVersionSourcePadded");
        public string CommitDate => GetFieldValue("CommitDate");

        private string GetFieldValue(string fieldName)
        {
            if (_values.TryGetValue(fieldName, out var value))
                return value;

            throw new UnknownGitVersionAssemblyVersion(fieldName);
        }
    }
}