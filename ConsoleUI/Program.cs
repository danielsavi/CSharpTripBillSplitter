using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using HelperLibrary;

namespace ConsoleUI
{
    /// <summary>
    /// 
    /// Some assumptions:
    /// 1. any invalid input will abort the process ...
    /// 2. All file manipulation in main program
    /// 3. I'm not sure about input '0', just ignoring...(after success parsing of it)
    /// 4. outfile file is always overwriten (if successed)
    /// 5. tested with some input files at [TestFiles] folder =)
    /// 
    /// </summary>

    class Program
    {
        private static List<string> inputLines;
        private static List<string> outputLines;
        private static List<Trip> trips;

        static void Main(string[] args)
        {
            //if (args.Length < 1)
            //{
            //    ShowHelp();
            //    return;
            //}

            try
            {
                //LoadFileData(args[0]);
                LoadFileData(@"c:\temp\input.txt");
                ParseFileDataToHelper();
                SplitBill();

                //SaveFileData(args[0]+".out");
                SaveFileData(@"c:\temp\out.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, please check your input file. Aborting: {0}", ex.Message);
                return;
            }

            Console.WriteLine("Finished...");
        }

        private static void LoadFileData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("file does not exists: '{0}'", filePath);
            }

            inputLines = File.ReadAllLines(filePath).ToList();
        }

        private static void ParseFileDataToHelper()
        {
            if (inputLines.Count == 0)
            {
                throw new Exception("nothing to parse");
            }

            trips = new List<Trip>();

            foreach (var line in inputLines)
            {
                decimal decimalValue = 0;
                int intValue = 0;
                
                if (line.Contains(".") && decimal.TryParse(line, out decimalValue))
                {
                    trips.LastOrDefault().AddReceiptToLastPerson(decimalValue);
                }

                else if (int.TryParse(line, out intValue))
                {
                    if (intValue > 0) // ignoring '0' inputs
                    {
                        if (trips.Count == 0 || trips.LastOrDefault().IsPeopleCompleted)
                        {
                            trips.Add(new Trip(intValue));
                        }
                        else
                        {
                            trips.LastOrDefault().AddPerson(intValue);
                        }
                    }
                }
            }
        }

        private static void SplitBill()
        {
            outputLines = new List<string>();
            foreach (var trip in trips)
            {
                decimal tripAmount = trip.People.Sum(x => x.TotalAmount);
                foreach (var person in trip.People)
                {
                    decimal bill = Bill.Calc(tripAmount, person.TotalAmount, trip.NumberOfPeople);
                    outputLines.Add(Bill.FormatDecimalToCustomString(bill));
                }
                outputLines.Add("");
            }
        }

        private static void SaveFileData(string filePath)
        {
            if (outputLines.Count == 0)
            {
                throw new Exception("nothing to save");
            }

            File.WriteAllLines(filePath, outputLines);
        }

        private static void ShowHelp()
        {
            Console.WriteLine("");
            Console.WriteLine("usage: <inputfile.txt>");
            Console.WriteLine("");
        }
    }
}
