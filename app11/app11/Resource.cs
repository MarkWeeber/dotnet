using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace app11
{
    struct Resource
    {
        public string fileName;
        private string pathToFile;
        public Resource(string fileName)
        {
            this.fileName = fileName;
            pathToFile =  Directory.GetCurrentDirectory() + @"\resources\";
            UpdateDirectory();
        }
        public void SaveToJson(object data)
        {
            UpdateDirectory();
            File.WriteAllText(pathToFile + fileName, JsonConvert.SerializeObject(data));
        }

        public T RetrieveFromJson<T>()
        {
            string fileContents;
            try
            {
                fileContents = File.ReadAllText(pathToFile + fileName);
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            catch (System.Exception)
            {
                return default(T);
            }
        }

        private void UpdateDirectory()
        {
            if(!Directory.Exists(pathToFile))
            {
                Directory.CreateDirectory(pathToFile);
            }
        }

    }
}