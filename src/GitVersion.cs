using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sovarto.ReadGitVersionInformation
{
    public static class GitVersion
    {
        private static readonly Dictionary<string, IGitVersionInformation> Cache =
            new Dictionary<string, IGitVersionInformation>();

        public static IGitVersionInformation GetVersionInformation() => GetVersionInformation(Assembly.GetCallingAssembly());

        public static IGitVersionInformation GetVersionInformation(Assembly assembly)
        {
            var name = assembly.GetName();
            if (Cache.TryGetValue(name.FullName, out var cached))
                return cached;

            var assemblyName = name.Name;

            IGitVersionInformation result;

            var gitVersionInformationType = assembly.GetType(assemblyName + ".GitVersionInformation") ??
                                            assembly.GetType("GitVersionInformation");
            if (gitVersionInformationType == null)
            {
                var informationalVersion = ((AssemblyInformationalVersionAttribute)assembly
                                                   .GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false)
                                                   .SingleOrDefault())?.InformationalVersion;
                if (informationalVersion != null &&
                    GitVersionInformationFromInformationalVersion.IsValidInformationalVersion(informationalVersion))
                    result = new GitVersionInformationFromInformationalVersion(informationalVersion);
                else
                    result = new AssemblyVersion(assembly);
            }
            else
                result = new GitVersionInformationFromClass(gitVersionInformationType.GetFields());

            Cache.Add(name.FullName, result);
            return result;
        }
    }
}