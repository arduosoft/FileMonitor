using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Config
{
    /// <summary>
    /// This class represent a filter for selecting files for looking for
    /// </summary>
    public class FileFilter
    {
        public string FileFolder { get; set; }
        /// <summary>
        /// with placeholder, like *.txt
        /// </summary>
        public string FileName { get; set; }


        public List<ActionToDo> OnChange  { get; set; }
        public List<ActionToDo> OnNew { get; set; }
        public List<ActionToDo> OnDeleted { get; set; }

    }
}
