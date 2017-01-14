using Arduosoft.FileMonitor.Plugins;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Config
{
    public class Configuration
    {
        [JsonIgnore]
        public ProcessorSet Processors { get; set; }

        public List<FileFilter> Filters { get; set;}

        public Configuration()
        {
            this.Processors = new ProcessorSet();
            Filters = new List<FileFilter>();
            LoadAllProcessors();
        }

        public void LoadAllProcessors()
        {
            //TODO: scan to fetch all Processor loaded
            this.Processors.Add(new Move());
        }

        static Configuration current;
        public static Configuration Current
        {
            get { return current ?? (current = new Configuration()); }
            set { current = value; }
        }
    }
}
