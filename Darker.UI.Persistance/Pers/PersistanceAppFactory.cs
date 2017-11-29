using Darker.Files;
using Darker.Files.Windows;
using Darker.Persistance;
using Darker.Serializing.Json;
using Darker.TextFilePersistance;

namespace Darker.UI.Persistance
{
    public class PersistanceAppFactory
    {

        public PersistanceFormApp Create()
        {
            PersistanceFormApp app = new PersistanceFormApp(
                ctrl: new PersistanceFormController(CreateStorage()),
                view: new Form1());
            return app;
        }

        Storage CreateStorage()
        {
            FileSystem filesystem = new WindowsFileSystem();
            var serializer = new JsonSerializer(readableFormatting:true);
            var path = filesystem.CreatePath(filesystem.TempDirectory, @"MyTestFile.json");
            var storage = new TextFileStorage(filesystem, serializer, path);
            return storage;
        }


    }
}
