using Arduosoft.FileMonitor.Config;
using Arduosoft.FileMonitor.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: implement args managment to allow option

            EnsureConfig();

            string confStr = File.ReadAllText(".\\conf.json");
            Configuration conf = GetConfig(confStr);
            Configuration.Current = conf;

            foreach (var item in conf.Filters)
            {
                // Create a new FileSystemWatcher and set its properties.
                EnanchedFileWatcher watcher = new EnanchedFileWatcher(item);
                

                // Begin watching.
                watcher.EnableRaisingEvents = true;
                
                Console.WriteLine("Listening... {0} {1}",item.FileFolder, item.FileName);
                // Wait for the user to quit the program.
               
            }


            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;

        }

        

        private static Configuration GetConfig(string confStr)
        {
           return JsonConvert.DeserializeObject<Configuration>(confStr);
        }

        private static void EnsureConfig()
        {
            if (!File.Exists(".\\conf.json"))
            {
                Dictionary<string, string> p = new Dictionary<string, string>();
                p["destination"] = "C:\\temp\\{filename}_{dt}.txt";

                Configuration tmp = new Configuration();
                tmp.Filters = new List<FileFilter>();
                tmp.Filters.Add(new FileFilter()
                {
                    FileFolder = "C:\\temp\\",
                    FileName = "*.txt",
                    OnChange = new List<ActionToDo>(new ActionToDo[] { new ActionToDo() {
                        ActionName="Move",
                        Arguments=p
                    } })

                });

                File.WriteAllText(".\\conf.json", JsonConvert.SerializeObject(tmp));

                
            }
        }
    }
}
