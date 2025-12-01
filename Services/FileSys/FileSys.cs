using Microsoft.AspNetCore.Http;

namespace HttpBSys.Services.FileSys
{
    public static class FileSys
    {
        const string fileExt = ".lzx";
        const string appFolderName = "Content";

        //private string appDirectory = string.Empty;
        // private string filePath = string.Empty;

        //public FileSys()
        //{
            //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //string appFolderName = "HttpBSysApp";
            
            //this.appDirectory = Path.Combine(appDataPath, appFolderName);
            //Directory.CreateDirectory(appDirectory);
            
            //filePath = Path.Combine(appDirectory, fileName);
        //}

        public static void Store(string data, string fileid)
        {
            try
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string appFolderName = "HttpBSysApp";

                string appDirectory = Path.Combine(appDataPath, appFolderName);
                Directory.CreateDirectory(appDirectory);

                fileid = string.IsNullOrWhiteSpace(fileid) ? Path.GetRandomFileName().Replace(".", "") : fileid;

                string filePath = Path.Combine(appDirectory, string.Concat(fileid,fileExt));

                File.WriteAllText(filePath, data);
                Console.WriteLine($"File saved successfully at: {filePath}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
        }

        public static string Read(string fileName)
        {
            try
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                

                string appDirectory = Path.Combine(appDataPath, appFolderName);
                Directory.CreateDirectory(appDirectory);

                string filePath = Path.Combine(appDirectory, fileName);

                string loadedData = File.ReadAllText(filePath);
                Console.WriteLine($"File loaded successfully. Data: {loadedData}");
                return loadedData;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found"); // at {filePath}
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            return string.Empty; 
        }

    }
}
