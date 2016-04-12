using System.IO;

namespace RSCoreLib
    {
    public static class DirectoryInfoExtensions
        {
        public static bool PointsToSameDirectory (this DirectoryInfo a, DirectoryInfo b)
            {
            return PathHelper.PointsToSameDirectory(a.FullName, b.FullName);
            }

        public static DirectoryInfo GetSubdirectory (this DirectoryInfo a, string name)
            {
            return new DirectoryInfo(PathHelper.EnsureTrailingDirectorySeparator(Path.Combine(a.FullName, name)));
            }
        }
    }
