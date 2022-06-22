using System.IO;
using Newtonsoft.Json;

namespace app11
{
    struct Resource
    {
        public string FileName;
        private string PathToFile;
        public Resource(string FileName)
        {
            this.FileName = FileName;
            PathToFile =  Directory.GetCurrentDirectory() + @"\resources\";
            UpdateDirectory();
        }
        public void SaveToJson(object data)
        {
            UpdateDirectory();
            File.WriteAllText(PathToFile + FileName, JsonConvert.SerializeObject(data));
        }

        public T RetrieveFromJson<T>()
        {
            string _fileContents;
            try
            {
                _fileContents = File.ReadAllText(PathToFile + FileName);
                return JsonConvert.DeserializeObject<T>(_fileContents);
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        private void UpdateDirectory()
        {
            if(!Directory.Exists(PathToFile))
            {
                Directory.CreateDirectory(PathToFile);
            }
        }

    }
}