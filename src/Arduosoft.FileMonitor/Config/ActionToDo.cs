using Arduosoft.FileMonitor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Config
{
    public class ActionToDo
    {
        public string ActionName { get; set; }

        public Dictionary<string,string> Arguments { get; set; }

        public ActionToDo()
        {

            Arguments = new Dictionary<string, string>();
          
            ActionName="UNSET";
        }
    }
}
