using System;
using System.Collections.Generic;
using System.IO;

namespace Darker.Files.Windows
{
    public class WindowsFileSystem : FileSystem
    {
        public string GetText(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath)) throw new ArgumentNullException(nameof(filepath));
            if (DirectoryExists(filepath)) throw new NotAFile(filepath);
            try
            {
                return File.ReadAllText(filepath);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(filepath, ua);
            }
            catch (FileNotFoundException nf)
            {
                throw new FileNotFound(filepath, nf);
            }
            catch (Exception ex)
            {
                throw new CannotReadFile(filepath, ex);
            }
        }

        public byte[] GetBytes(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath)) throw new ArgumentNullException(nameof(filepath));
            try
            {
                return File.ReadAllBytes(filepath);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(filepath, ua);
            }
            catch (FileNotFoundException nf)
            {
                throw new FileNotFound(filepath, nf);
            }
            catch (Exception ex)
            {
                throw new CannotReadFile(filepath, ex);
            }
        }

        public bool FileExists(string path)
        {
            try
            {
                return File.Exists(path);
            }
            catch (UnauthorizedAccessException)
            {
                return true;
            }
        }


        public bool DirectoryExists(string path) => Directory.Exists(path);

        public bool IsValid(string filePath)
        {
            try
            {
                var fi = new FileInfo(filePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsDirectoryAccessable(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory)) return false;
            if (FileExists(directory)) return false;
            try
            {
                var di = new DirectoryInfo(directory);
                var files = GetFilesIn(directory);
                return DirectoryExists(directory);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<string> GetFilesIn(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory)) throw new ArgumentNullException(nameof(directory));
            if (FileExists(directory)) throw new NotADirectory(directory);
            if (!DirectoryExists(directory)) throw new DirectoryNotFound(directory);

            try
            {
                return Directory.GetFiles(directory);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(directory, ua);
            }
            catch (Exception ex)
            {
                throw new Unknown(directory, ex);
            }
        }

        public IEnumerable<string> GetSubDirectoriesIn(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory)) throw new ArgumentNullException(nameof(directory));
            if (FileExists(directory)) throw new NotADirectory(directory);
            if (!DirectoryExists(directory)) throw new DirectoryNotFound(directory);


            try
            {
                return Directory.GetDirectories(directory);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(directory, ua);
            }
            catch (Exception ex)
            {
                throw new Unknown(directory, ex);
            }
        }

        public void Create(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath)) throw new ArgumentNullException(nameof(filepath));
            if (FileExists(filepath)) throw new FileAlreadyExists(filepath);
            if (DirectoryExists(filepath)) throw new NotAFile(filepath);
            try
            {
                File.Create(filepath);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(filepath, ua);
            }
            catch (Exception ex)
            {
                throw new CannotCreateFile(filepath, ex);
            }
        }

        public void Create(string filepath, string content)
        {
            if (string.IsNullOrWhiteSpace(filepath)) throw new ArgumentNullException(nameof(filepath));
            if (FileExists(filepath)) throw new FileAlreadyExists(filepath);
            Replace(filepath, content);
        }

        public void Create(string filepath, byte[] content)
        {
            if (string.IsNullOrWhiteSpace(filepath)) throw new ArgumentNullException(nameof(filepath));
            if (FileExists(filepath)) throw new FileAlreadyExists(filepath);
            Replace(filepath, content);
        }

        public void Replace(string filePath, string content)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (!FileExists(filePath)) throw new FileDoesNotExist(filePath);
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(filePath, ua);
            }
            catch (Exception ex)
            {
                throw new CannotCreateFile(filePath, ex);
            }
        }

        public void Replace(string filePath, byte[] content)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (!FileExists(filePath)) throw new FileDoesNotExist(filePath);
            try
            {
                File.WriteAllBytes(filePath, content);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(filePath, ua);
            }
            catch (Exception ex)
            {
                throw new CannotCreateFile(filePath, ex);
            }
        }

        public void Move(string fromPath, string toPath)
        {
            if (string.IsNullOrWhiteSpace(toPath)) throw new ArgumentNullException(nameof(toPath));
            if (string.IsNullOrWhiteSpace(fromPath)) throw new ArgumentNullException(nameof(fromPath));
            try
            {
                File.Move(fromPath, toPath);
            }
            catch (UnauthorizedAccessException ua)
            {
                throw new UnauthorizedAccess(toPath, ua);
            }
            catch (Exception ex)
            {
                throw new CannotMoveFile(fromPath, toPath, ex);
            }
        }

        public bool Delete(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;
                File.Delete(filePath);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public bool CanAccess(string file)
        {
            try
            {
                using (var stream = File.OpenRead(file))
                {
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string CurrentDirectory => Environment.CurrentDirectory;
        public string HomeDirectory => Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
        public string TempDirectory => Path.GetTempPath();
    }
}