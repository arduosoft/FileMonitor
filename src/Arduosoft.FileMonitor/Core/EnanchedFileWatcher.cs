using Arduosoft.FileMonitor.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Core
{
    public class EnanchedFileWatcher : FileSystemWatcher
    {
      

        public EnanchedFileWatcher(FileFilter filter) 
        {
            this.FileFilter = filter;



            base.Path = filter.FileFolder;
            Console.WriteLine("part:{0}", this.Path);
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            base.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            // Only watch text files.
            this.Filter = filter.FileName;

            Console.WriteLine("filter:{0}", this.Filter);

            // Add event handlers.
            this.Changed += Watcher_Changed;
            this.Created += Watcher_Created;
            this.Deleted += Watcher_Deleted;


        }

        public FileFilter FileFilter { get;set;}






         private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {


            NotifyEvent(FileChangeEvent.Deleted, e, ((EnanchedFileWatcher)sender).FileFilter);
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            NotifyEvent(FileChangeEvent.Changed, e, ((EnanchedFileWatcher)sender).FileFilter);
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            NotifyEvent(FileChangeEvent.Created, e, ((EnanchedFileWatcher)sender).FileFilter);
        }


        public static void NotifyEvent(FileChangeEvent type, FileSystemEventArgs e,FileFilter filter)
        {
            FileInfo f = files.FirstOrDefault(x => x.FilePath.Equals(e.FullPath, StringComparison.InvariantCultureIgnoreCase));
            if (f == null)
            {
                f = new FileInfo();
                f.FilePath = e.FullPath;
                f.Name = e.Name;
                files.Add(f);
            }

            if (File.Exists(e.FullPath))
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(e.FullPath);
           
                f.History.Insert(0, new FileStatus()
                {
                    CreateDate = fi.CreationTime,
                    LastWrite = fi.LastWriteTime,
                    Size = fi.Length,
                    Info = fi
                });
            }

            List<ActionToDo> actions = new List<ActionToDo>();
            //TODO add default action here
            switch (type)
            {
                case FileChangeEvent.Changed: actions.AddRange(filter.OnChange.ToArray()); break;
                case FileChangeEvent.Created: actions.AddRange(filter.OnNew.ToArray()); break;
                case FileChangeEvent.Deleted: actions.AddRange(filter.OnDeleted.ToArray()); break;
            }

            EventContext context;
            
            foreach (var action in actions)
            {
                string name = action.ActionName;
                var p=Configuration.Current.Processors[name];
                context = new EventContext(type, f, action.Arguments);

                p.Process(context);
            }
        }


        private static List<FileInfo> files = new List<FileInfo>();
    }
}
