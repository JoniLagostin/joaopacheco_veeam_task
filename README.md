# Folder Synchronization Utility

### Overview
A simple C# console application to synchronize files between two directories at a specified interval.\
Garantees that destination folder content is a strick copy of source folder.

### Usage
#### Arguments
**Source Directory Path:** The directory to copy files from.\
**Destination Directory Path:** The directory to copy files to.\
**Sync Interval (in seconds):** How often to sync the directories.\
**Log File Path:** Where to log the sync operations.


### Example
	dotnet run "C:\source" "C:\destination" 60 "C:\logs\sync.log"

 
### Tests
A small number of tests were written to test the execution of the MD5 algorithm.
