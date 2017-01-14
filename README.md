# FileMonitor
File Monitor is an utility for monitor changes and automate action on them


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


