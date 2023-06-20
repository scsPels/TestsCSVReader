using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestCodeCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the list of CSV files in the current directory.     

                var files = Directory.GetFiles(".\\Input Files", "*.csv");

            // Create a dictionary to store the test code counts by client code.
            //var counts = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> counts = new();

            // Iterate over the CSV files and count the number of each test code.
            foreach (var file in files)
            {
                // Create a reader for the CSV file.
                using (var reader = new StreamReader(file))
                {
                    // Read the header row.
                    reader.ReadLine();

                    // Iterate over the rows in the CSV file.
                    while (true)
                    {
                        // Read a row from the CSV file.
                        var line = reader.ReadLine();

                        // Break out of the loop if there are no more rows.
                        if (line == null)
                        {
                            break;
                        }

                        // Split the row into columns.
                        var columns = line.Split(',');

                        // Get the client code and test code from the row.
                        var clientCode = columns[1];
                        var testCode = columns[3];

                          if (!counts.ContainsKey(clientCode))
                {
                    counts[clientCode] = new Dictionary<string, int>();
                }

                Dictionary<string, int> testCodeCounts = counts[clientCode];
                if (!testCodeCounts.ContainsKey(testCode))
                {
                    testCodeCounts[testCode] = 0;
                }

                testCodeCounts[testCode]++;
            }
                       
                    }
                }
            //*******LOCAL TRANSACTION LOG***********
             using (var kennyLoggin = new StreamWriter("transaction_log.txt"))           
            kennyLoggin.WriteLine("Read Files from Input folder.");
            

            //Essentially creating/overwriting the txt file > closing> re-opening and writing. 
            //Messy fix for overwrite issue. 
             StreamWriter writer = new StreamWriter("test_code_counts.txt");
             writer.Close();
             writer = new StreamWriter("test_code_counts.txt",true);
             writer.AutoFlush= true;
                
            foreach (KeyValuePair<string, Dictionary<string, int>> count in counts)
            {
                foreach (KeyValuePair<string, int> testCodeCount in count.Value)
                {
                    writer.WriteLine("Client Code: {0}, Test Code: {1} Total Count: {2}", count.Key, testCodeCount.Key, testCodeCount.Value);
                }
            }

            //*******LOCAL TRANSACTION LOG***********.
            using (var kennyLoggin = new StreamWriter("transaction_log.txt",true))          
            kennyLoggin.WriteLine("Test code counts written to test_code_counts.txt");

            // Generate mock output CSVs for each input CSV.
            foreach (var file in files)
            {
                // Create a writer for the output CSV file.
                var curFileName = Path.GetFileName(file);
                var outputFile = Path.Combine(Directory.GetCurrentDirectory(), "Output Files", curFileName);
                using (var outputWriter = new StreamWriter(outputFile))
                {
                    // Write the header row to the output CSV file.
                    outputWriter.WriteLine("Patient Name,Client Code,Sample ID,Test Code,Date of Service,Result");

                    // Read the input CSV file and write a mock output row for each row.
                    using (var reader = new StreamReader(file))
                    {
                        reader.ReadLine();

                        while (true)
                        {
                            // Read a row from the input CSV file.
                            var line = reader.ReadLine();

                            // Break out of the loop if there are no more rows.
                            if (line == null)
                            {
                                break;
                            }

                            // Generate a mock result for the row.
                            Random rand = new Random();
                            var result = rand.Next(0, 2) == 0 ? "Positive" : "Negative";

                            // Write the mock output row to the output CSV file.
                            outputWriter.WriteLine(line + "," + result);
                        }
                    }
                }
            }
            //*******LOCAL TRANSACTION LOG***********
            using (var kennyLoggin = new StreamWriter("transaction_log.txt",true))
            kennyLoggin.WriteLine("Mock output CSVs generated");
      
        }
    }
}

