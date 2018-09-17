using Xunit;

namespace ReadGitVersionInformation.UnitTests
{
    public class ParseInformationalVersion
    {
        [Fact]
        public void InformationalVersionWithoutPrereleaseTagIsParsedCorrectly()
        {
            var informationalVersion = "2.1.0+Branch.master.Sha.dacbab0bb87aec89b799957f73392d64ff8c828c";

            var actual = new GitVersionInformationFromInformationalVersion(informationalVersion);

            Assert.Equal("2", (string)actual.Major);
            Assert.Equal("1", (string)actual.Minor);
            Assert.Equal("0", (string)actual.Patch);
            Assert.Equal("", (string)actual.PreReleaseTag);
            Assert.Equal("", (string)actual.PreReleaseTagWithDash);
            Assert.Equal("", (string)actual.PreReleaseLabel);
            Assert.Equal("", (string)actual.PreReleaseNumber);
            Assert.Equal("", (string)actual.BuildMetaData);
            Assert.Equal("", (string)actual.BuildMetaDataPadded);
            Assert.Equal("Branch.master.Sha.dacbab0bb87aec89b799957f73392d64ff8c828c", (string)actual.FullBuildMetaData);
            Assert.Equal("2.1.0", (string)actual.MajorMinorPatch);
            Assert.Equal("2.1.0", (string)actual.SemVer);
            Assert.Equal("2.1.0", (string)actual.LegacySemVer);
            Assert.Equal("2.1.0", (string)actual.LegacySemVerPadded);
            Assert.Equal("2.1.0.0", (string)actual.AssemblySemVer);
            Assert.Equal("2.1.0", (string)actual.FullSemVer);
            Assert.Equal(informationalVersion, (string)actual.InformationalVersion);
            Assert.Equal("master", (string)actual.BranchName);
            Assert.Equal("dacbab0bb87aec89b799957f73392d64ff8c828c", (string)actual.Sha);
            Assert.Equal("2.1.0", (string)actual.NuGetVersionV2);
            Assert.Equal("2.1.0", (string)actual.NuGetVersion);
            Assert.Equal("", (string)actual.CommitsSinceVersionSource);
            Assert.Equal("", (string)actual.CommitsSinceVersionSourcePadded);
            Assert.Equal("0001-01-01", (string)actual.CommitDate);
        }
}