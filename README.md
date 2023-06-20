# CSVReader
 CSV Reader that reads and writes CSV files based on column criteria

expects the Input and Output folders wherever your directory is running from. 


 Tested in Debug, but didn't go through the whole process of trying to set it up for a Release as I'm not very practiced with that, even in my workstation IDEs. If that's something you'd prefer me do let me know and I can try to add that as well. 





 Write a simple, console applica�on using C#.
Assume the following informa�on:
• A local directory populated with CSV files.
• CSV columns: Pa�ent Name, Client Code, Sample ID, Test Code, Date of Service
• A local output directory
The applica�on must perform the following ac�ons:
• Find and read all CSV files in the local directory.
• Output to a text file a count of how many of each test code were found, by client code.
• Generate a mock output CSV for each input CSV, with the following columns:
Pa�ent Name, Client Code, Sample ID, Test Code, Date of Service, Result
(The result field will be either “Posi�ve” or “Nega�ve”)
• Log transac�onal steps to a local file
• Full excep�on handling
