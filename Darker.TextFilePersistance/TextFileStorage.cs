using Darker.Files;
using Darker.Persistance;
using Darker.Serializing;

namespace Darker.TextFilePersistance
{
    public class TextFileStorage : Storage
    {
        private readonly FileSystem _files;
        private readonly TextSerializer _serializer;

        public TextFileStorage(FileSystem files, TextSerializer serializer,string filePath)
        {
            _files = files;
            _serializer = serializer;
            FilePath = filePath;
        }

        public string FilePath { get; set; }

        public void Save<T>(T item)
        {
           SaveToFile(FilePath, item);
        }

        public T Load<T>() => LoadFromFile<T>(FilePath);

        public void SaveToFile<T>(string filePath, T item)
        {
            var text = _serializer.Serialize(item);
            if (_files.FileExists(filePath))
                _files.Replace(filePath, text);
            else
                _files.Create(filePath, text);
        }

        public T LoadFromFile<T>(string filePath) => _serializer.Deserialize<T>(_files.GetText(filePath));
    }
}