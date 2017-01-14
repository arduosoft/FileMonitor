# FileMonitor
File Monitor is an utility for monitor changes and automate action on them. You need this program if you want to do something like the case below, **without writing a line of code**:

* Copy a file from location A to locatio B
* Roll a file basing on size
* Do something when some user (or one specific user) edit a file 
* Send an email when some file is deleted
* Send an alert when a file become bigger than a given value
* Count number of access on a file in a given amount of time



##How to use
1. Download "dist" folder
2. set up config.json
3. run executable 

##How to configure
Configure FileMonitor is easy you just have to 

1. list all file you want to listen. Each entry can be a set of file using * selector. You can specify many set of file by adding an entry in "Filters" property of config (see example below)
2. For each *Filter* (set of file to be monitored) you can specify many *action* to do on a given *event*
3. Each action is described by an ActionName (Move,Copy, SendEmail,etc..) and basing on action type could need additiona parameter, i.e. the recipient for email to send in SendEmail case.



##Example of usage
create a file "config.json" (on template will be create if missing)

Foreach file filter you can specify wich action to do for each event.

```json
{
  "Filters": [
    {
      "FileFolder": "C:\\temp\\",
      "FileName": "*.txt",
      "OnChange": [
        {
          "ActionName": "Move",
          "Arguments": { "destination": "C:\\temp\\{filename}_{dt}.txt" }
        }
      ],
      "OnNew": null,
      "OnDeleted": null
    }
  ]
}
```

##Core Actions
Here are reported the action shipped with FileMonitor. Many addctional action can be implemented by following the guide above. 

ActionName|Description|
--------------------------------
Move| move the file monitored to a destination| 

##Contributor Actions
Please contact us opening an issue to have you plugin listed here.

ActionName|Description|Author|
------------------------------


##How to extend a plugin

You just have to implement FileProcessor class, where
* *ActionName:* is the name of the action. It have to be unique, so it's a good idea to use a prefix in case you whant to share it with others, to avoid naming collision. i.e. you can use mynickname.Action insthead of Action. _just place an hardcoded string_
* *Process:* Take in input all an object that stores:
        * info about the file and history of last changes
        * arguments specified by the user in config.json for your action, 
        * the result of previous steps

```cs
 public class Move : Core.FileProcessor
    {
        public override string ActionName
        {
            get
            {
                return "Move";
            }
        }

        public override void Process(EventContext context)
        {
            if (!context.Arguments.ContainsKey("destination")) throw new Exception("Move action requires destination field");

            string destination = context.Arguments["destination"];
            destination = destination.Replace("{filename}", Path.GetFileName(context.File.FilePath));
            destination = destination.Replace("{sourceDir}", Path.GetDirectoryName(context.File.FilePath));
            destination = destination.Replace("{sourceExt}", Path.GetExtension(context.File.FilePath));
            destination = destination.Replace("{dt}", DateTime.Now.ToString("yyyy-MM-dd-HHmmSS"));
            File.Move(context.File.FilePath, destination);
        }
    }
```

Do you want to try coding? It's simple to start: just 
1. open your ide and create a library project
2. add FileMonitor from nuget. This will allow you to see interface and classes from the core
3. implement your file processor using this guide
4. copy your library and all dependencies on the path
5. edit config.json and run FileMonitor

#License


