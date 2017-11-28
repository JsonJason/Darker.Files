using System;
using System.Linq;
using NUnit.Framework;

namespace Darker.Files.Windows.Tests
{
    [TestFixture]
    public class WindowsFileSystemTests
    {
        [SetUp]
        public void Setup()
        {
            _files = new WindowsFileSystem();
        }

        private WindowsFileSystem _files;
        private const string unauthorizedDirectory = @"C:\$SysReset";
        private const string unauthorizedFile = @"C:\$SysReset\UNAUTH.txt";
        private const string homeDirectory = @"C:\Users\jason";
        private const string tempDirectory = @"C:\Users\jason\AppData\Local\Temp\";
        private const string nonexistentFile = "GIBBERISH.txt";

        private const string existingDirectory =
            @"C:\Users\jason\Desktop\DarkerLibs\Darker.Files\Darker.Files\Darker.Files.Windows.Tests\bin\TestDirectory";

        private const string nonexistingDirectory =
                @"C:\Users\jason\Desktop\DarkerLibs\Darker.Files\Darker.Files\Darker.Files.Windows.Tests\bin\NotRealDirectory"
            ;

        private readonly string existingfile =
            @"C:\Users\jason\Desktop\DarkerLibs\Darker.Files\Darker.Files\Darker.Files.Windows.Tests\bin\testfile.txt";

        public void Delete_File_WithNull_False()
        {
            Assert.IsFalse(_files.Delete(""));
            Assert.IsFalse(_files.Delete(null));
        }

        public void CreateFile_UnAuth_Throws()
        {
            Assert.Throws<FileAlreadyExists>(() => _files.Create(unauthorizedFile));
            Assert.Throws<NotAFile>(() => _files.Create(unauthorizedDirectory));
        }

        [Test]
        public void Calling_DirectoryExists_When_Does_Returns_True()
        {
            Assert.IsTrue(_files.DirectoryExists(existingDirectory));
        }

        [Test]
        public void Calling_DirectoryExists_When_Doesnt_Returns_False()
        {
            Assert.IsFalse(_files.DirectoryExists(nonexistingDirectory));
        }

        [Test]
        public void Calling_DirectoryExists_With_Nulls_Returns_False()
        {
            Assert.IsFalse(_files.FileExists(""));
            Assert.IsFalse(_files.FileExists(null));
        }

        [Test]
        public void Calling_FileExists_When_Does_Returns_True()
        {
            Assert.IsTrue(_files.FileExists(existingfile));
        }

        [Test]
        public void Calling_FileExists_When_Doesnt_Returns_False()
        {
            Assert.IsFalse(_files.FileExists(nonexistentFile));
        }

        [Test]
        public void Calling_FileExists_With_Nulls_Returns_False()
        {
            Assert.IsFalse(_files.FileExists(""));
            Assert.IsFalse(_files.FileExists(null));
        }


        [Test]
        public void CanAccess_When_authorized_Returns_True()
        {
            var canAccess = _files.CanAccess(existingfile);
            Assert.IsTrue(canAccess);
        }

        [Test]
        public void CanAccess_When_Unauthorized_Returns_False()
        {
            var canAccess = _files.CanAccess(unauthorizedFile);
            Assert.IsFalse(canAccess);
        }

        [Test]
        public void CreateFile_Directory_Throws()
        {
            Assert.Throws<NotAFile>(() => _files.Create(existingDirectory));
        }

        [Test]
        public void CreateFile_Empty_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _files.Create(null));
            Assert.Throws<ArgumentNullException>(() => _files.Create(""));
        }

        [Test]
        public void CreateFile_Existing_Throws()
        {
            Assert.Throws<FileAlreadyExists>(() => _files.Create(existingfile));
        }

        [Test]
        public void Delete_File_Returns_True()
        {
            var temp = _files.TempDirectory + @"\Test.txt";

            if (!_files.FileExists(temp))
                _files.Create(temp);

            var didDelete = _files.Delete(temp);
            Assert.IsTrue(didDelete);
        }

        [Test]
        public void Delete_File_With_No_File_Returns_False()
        {
            var didDelete = _files.Delete("asdfasdf");
            Assert.IsFalse(didDelete);
        }

        [Test]
        public void Delete_With_UnAuth_File_Returns_False()
        {
            var didDelete = _files.Delete(unauthorizedFile);
            Assert.IsFalse(didDelete);
        }

        [Test]
        public void DirectoryAccessable_NotExists_False()
        {
            Assert.IsFalse(_files.IsDirectoryAccessable(nonexistingDirectory));
        }

        [Test]
        public void DirectoryAccessable_WhenExisting_True()
        {
            Assert.IsTrue(_files.IsDirectoryAccessable(existingDirectory));
        }

        [Test]
        public void DirectoryAccessable_WhenFile_False()
        {
            Assert.IsFalse(_files.IsDirectoryAccessable(existingfile));
        }

        [Test]
        public void DirectoryAccessable_WhenNoAccess_False()
        {
            Assert.IsFalse(_files.IsDirectoryAccessable(unauthorizedDirectory));
        }

        [Test]
        public void DirectoryAccessable_WhenNoAccessFile_False()
        {
            Assert.IsFalse(_files.IsDirectoryAccessable(unauthorizedFile));
        }

        [Test]
        public void DirectoryAccessable_WhenNonExistingFile_False()
        {
            Assert.IsFalse(_files.IsDirectoryAccessable(nonexistentFile));
        }

        [Test]
        public void Get_Directorys_Returns_DirectoryList()
        {
            var files = _files.GetSubDirectoriesIn(existingDirectory);
            Assert.AreEqual(1, files.Count());
        }


        [Test]
        public void Get_Files_Returns_FileList()
        {
            var files = _files.GetFilesIn(existingDirectory);
            Assert.AreEqual(3, files.Count());
        }


        [Test]
        public void GetFiles_Null_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => _files.GetFilesIn(""));

            Assert.Throws<ArgumentNullException>(() => _files.GetFilesIn(null));
        }

        [Test]
        public void GetFilesIn_Throw()
        {
            Assert.Throws<NotADirectory>(() => _files.GetFilesIn(existingfile));
        }

        [Test]
        public void GetFilesInNonExisting_Throw()
        {
            Assert.Throws<DirectoryNotFound>(() => _files.GetFilesIn(nonexistingDirectory));
        }

        [Test]
        public void GetFilesInUnAuthorized_Throw()
        {
            Assert.Throws<UnauthorizedAccess>(() => _files.GetFilesIn(unauthorizedDirectory));
        }


        [Test]
        public void GetSubDirectories_Null_Throw()
        {
            Assert.Throws<ArgumentNullException>(() => _files.GetSubDirectoriesIn(""));

            Assert.Throws<ArgumentNullException>(() => _files.GetSubDirectoriesIn(null));
        }

        [Test]
        public void GetSubDirectoriesInFile_Throw()
        {
            Assert.Throws<NotADirectory>(() => _files.GetSubDirectoriesIn(existingfile));
        }

        [Test]
        public void GetSubDirectoriesInNonExisting_Throw()
        {
            Assert.Throws<DirectoryNotFound>(() => _files.GetSubDirectoriesIn(nonexistingDirectory));
        }

        [Test]
        public void GetSubDirectoriesInUnAuthorized_Throw()
        {
            Assert.Throws<UnauthorizedAccess>(() => _files.GetSubDirectoriesIn(unauthorizedDirectory));
        }

        [Test]
        public void GetText_BlankString_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _files.GetText(""));
            Assert.Throws<ArgumentNullException>(() => _files.GetText(null));
        }

        [Test]
        public void GetText_Directory_Throws_NotFile()
        {
            Assert.Throws<NotAFile>(() => _files.GetText(existingDirectory));
        }

        [Test]
        public void GetText_Non_Existent_File_Throws()
        {
            Assert.Throws<FileNotFound>(() => _files.GetText(nonexistentFile));
        }


        [Test]
        public void GetText_Returns_Text()
        {
            var text = _files.GetText(existingfile);
            Assert.AreEqual("Hello World!!!", text);
        }


        [Test]
        public void GetText_UnAuthorized_Throws()
        {
            Assert.Throws<UnauthorizedAccess>(() => { _files.GetText(unauthorizedFile); });
        }

        [Test]
        public void HomeDirectory_Returns()
        {
            var home = _files.HomeDirectory;
            Assert.AreEqual(homeDirectory, home);
        }

        [Test]
        public void RootDirectory_Returns()
        {
            var temp = _files.TempDirectory;
            Assert.AreEqual(tempDirectory, temp);
        }
    }
}