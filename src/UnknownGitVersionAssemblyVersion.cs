using System;

namespace Sovarto.ReadGitVersionInformation
{
    internal class UnknownGitVersionAssemblyVersion : Exception
    {
        public UnknownGitVersionAssemblyVersion(string fieldName)
            : base(
                $"The field '{fieldName}' is not a known property of the automatically generated GitVersionInformation class. This most likely hints at a version mismatch.") =>
            FieldName = fieldName;

        public string FieldName { get; }
    }
}