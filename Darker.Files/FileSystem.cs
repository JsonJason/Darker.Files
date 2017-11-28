using System.Collections.Generic;

namespace Darker.Files
{
    public interface FileSystem
    {
        string CurrentDirectory { get; }
        string HomeDirectory { get; }
        string TempDirectory { get; }

        string GetText(string filePath);
        byte[] GetBytes(string filePath);
        bool FileExists(string filePath);
        bool DirectoryExists(string filePath);
        bool CanAccess(string filePath);
        bool Delete(string filePath);
        bool IsValid(string filePath);
        bool IsDirectoryAccessable(string directory);
        IEnumerable<string> GetFilesIn(string directory);
        IEnumerable<string> GetSubDirectoriesIn(string directory);

        void Create(string filePath);
        void Create(string filePath, string content);
        void Create(string filePath, byte[] content);

        void Replace(string filePath, string content);
        void Replace(string filePath, byte[] content);


        void Move(string fromPath, string toPath);
    }
}