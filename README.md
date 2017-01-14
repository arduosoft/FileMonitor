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

ActionName|Description
--------------------------------
Move| move the file monitored to a destination| 

##Contributor Actions
Please contact us opening an issue to have you plugin listed here.
ActionName|Description|Author|
------------------------------


##How to extend a plugin
