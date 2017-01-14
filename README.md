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


