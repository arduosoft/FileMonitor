# FileMonitor
File Monitor is an utility for monitor changes and automate action on them

##How to use
1. Downlod "dist" folder
2. set up config.json
3. run executable 

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


