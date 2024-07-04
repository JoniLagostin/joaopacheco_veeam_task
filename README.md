# Folder Synchronization Utility

### Overview
A simple C# console application to synchronize files between two directories at a specified interval.

### Usage
#### Arguments
**Source Directory Path:** The directory to copy files from.
**Destination Directory Path:** The directory to copy files to.
**Sync Interval (in seconds):** How often to sync the directories.
**Log File Path:** Where to log the sync operations.


### Example
	dotnet run "C:\source" "C:\destination" 60 "C:\logs\sync.log"


### Tests
A small number of tests where performed to test the MD5 algorithm
