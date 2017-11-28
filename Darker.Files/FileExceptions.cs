using System;

namespace Darker.Files
{
    public class NotAFile : FileSystemException
    {
        public NotAFile(string path) : this(path, "Provided path is not a file")
        {
        }

        public NotAFile(string path, Exception inner) : this(path, "Provided path is not a file", inner)
        {
        }

        public NotAFile(string path, string message, Exception inner) : base(path, message, inner)
        {
        }

        public NotAFile(string path, string message) : base(path, message)
        {
        }
    }

    public class NotADirectory : DirectoryException
    {
        public NotADirectory(string path) : this(path, "Provided path is not a directory")
        {
        }

        public NotADirectory(string path, Exception inner) : this(path, "Provided path is not a directory", inner)
        {
        }

        public NotADirectory(string path, string message, Exception inner) : base(path, message, inner)
        {
        }

        public NotADirectory(string path, string message) : base(path, message)
        {
        }
    }

    public class CannotCreateFile : FileSystemException
    {
        public CannotCreateFile(string path, Exception inner) : base(path, "File Could not be created", inner)
        {
        }

        public CannotCreateFile(string path) :
            base(path, "File Could not be created")
        {
        }
    }

    public class FileAlreadyExists : FileSystemException
    {
        public FileAlreadyExists(string path, Exception inner) : base(path, "File Already Exists", inner)
        {
        }

        public FileAlreadyExists(string path) : base(path, "File Already Exists")
        {
        }
    }

    public class FileDoesNotExist : FileSystemException
    {
        public FileDoesNotExist(string path, Exception inner) : base(path, "File Does Not Exist", inner)
        {
        }

        public FileDoesNotExist(string path) : base(path, "File Does Not Exist")
        {
        }
    }

    public class CannotMoveFile : FileSystemException
    {
        public CannotMoveFile(string from, string to, Exception inner) : base(to, "File Could not be moved", inner)
        {
            FromPath = from;
        }

        public CannotMoveFile(string from, string to) :
            base(to, "File Could not be moved")
        {
            FromPath = from;
        }

        public string FromPath { get; }
    }

    public class FileNotFound : FileSystemException
    {
        public FileNotFound(string path) : base(path, "File Not Found")
        {
        }

        public FileNotFound(string path, Exception baseException) : base(path, "File Not Found", baseException)
        {
        }
    }

    public class DirectoryNotFound : FileSystemException
    {
        public DirectoryNotFound(string path) : base(path, "Directory Not Found")
        {
        }

        public DirectoryNotFound(string path, Exception baseException) : base(path, "Directory Not Found",
            baseException)
        {
        }
    }


    public class UnauthorizedAccess : FileSystemException
    {
        public UnauthorizedAccess(string path) : base(path, "Cannot access file. Unauthorized.")
        {
        }

        public UnauthorizedAccess(string path, Exception baseException)
            : base(path, "Cannot access file. Unauthorized.", baseException)
        {
        }
    }

    public class CannotReadFile : FileSystemException
    {
        public CannotReadFile(string file) : base(file, "Cannot Read File.")
        {
        }

        public CannotReadFile(string file, Exception baseException) : base(file, "Cannot Read File", baseException)
        {
        }
    }

    public class FileSystemException : Exception
    {
        public FileSystemException(string path, string message, Exception inner) : base(message, inner)
        {
            Path = path;
        }

        public FileSystemException(string path, string message) : base(message)
        {
            Path = path;
        }

        public string Path { get; }
    }

    public class DirectoryException : FileSystemException
    {
        public DirectoryException(string path, string message, Exception inner) : base(path, message, inner)
        {
        }

        public DirectoryException(string path, string message) : base(path, message)
        {
        }
    }

    public class Unknown : FileSystemException
    {
        public Unknown(string path, Exception inner) : base(path, "Unknown Exception Occurred", inner)
        {
        }
    }
}