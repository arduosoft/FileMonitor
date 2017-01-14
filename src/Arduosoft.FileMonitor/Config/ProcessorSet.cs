using Arduosoft.FileMonitor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Config
{
    public class ProcessorSet:List<FileProcessor>
    {
        public FileProcessor this[string name]
        {
            get
            {
                return this.FirstOrDefault(x => x.ActionName == name);
            }

        }
    }
}
