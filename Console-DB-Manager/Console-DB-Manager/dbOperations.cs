using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Console_DB_Manager
{
    internal class dbOperations
    {

        private static showErrorMessage errMessage = new showErrorMessage();

        private string dbToManip = string.Empty;

        private Dictionary<string, string[]> tableData = new Dictionary<string, string[]>();

        private Regex pattern = new Regex("^[0-9]+$", RegexOptions.IgnoreCase);

        public void setDbToManip(string dbToManip)
        {
            this.dbToManip = dbToManip;
        }

        private void retrieveData()
        {
            tableData = new Dictionary<string, string[]>();
            string filePath = dbToManip == "1" ? "acc_table.csv" : "main_table.csv";
            string fileLine = string.Empty;
            string[] fileLineCont = new string[] { };
            int rowCounter = 0;

            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((fileLine = sr.ReadLine()) != null)
                {
                    fileLineCont = new string[fileLine.Split(',').Length];
                    fileLineCont = fileLine.Split(',');

                    tableData.Add($"row{rowCounter + 1}", fileLineCont);
                    rowCounter++;
                }
            }
        }

        private void checkTableExists()
        {
            string filePath = dbToManip == "1" ? "acc_table.csv" : "main_table.csv";
            if (!File.Exists(filePath))
            {
                string errorMessage = errMessage.DisplayErrorMessage(1);
                Console.Write(errorMessage);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void showData()
        {
            checkTableExists();
            retrieveData();
            string userProc = string.Empty;
            string errorMessage = string.Empty;

            while (userProc.ToLower() != "y")
            {
                Console.Clear();
                for (int x = 0; x < tableData.Count; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(tableData.Keys.ElementAt(x) + " -> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int y = 0; y < tableData.Values.ElementAt(x).Length; y++)
                    {
                        Console.Write(tableData.Values.ElementAt(x)[y] + " | ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.Write("return to main menu?: [y/N]\nAnswer: ");
                userProc = Console.ReadLine();

                if (userProc.ToLower() != "y" && userProc.ToLower() != "n")
                {
                    Console.Clear();
                    errorMessage = errMessage.DisplayErrorMessage(7);
                    Console.Write(errorMessage);
                    Console.ReadKey();
                }
            }
        }

        public void addData()
        {
            checkTableExists();
            retrieveData();
            string userProc = string.Empty;
            string errorMessage = string.Empty;
            string[] newData = new string[3];
            string filePath = dbToManip == "1" ? "acc_table.csv" : "main_table.csv";

            while (userProc.ToLower() != "n")
            {
                Console.Clear();
                newData = new string[3];
                if (dbToManip != "2")
                {
                    Console.Write("Name: ");
                    newData[0] = Console.ReadLine().Trim();
                    Console.Write("Password: ");
                    newData[1] = Console.ReadLine().Trim();
                    Console.Write("Authorization Level (Can only be [A | SA]): ");
                    newData[2] = Console.ReadLine().Trim();

                    if (newData[2].Length > 2 || newData[2] == string.Empty)
                    {
                        Console.Clear();
                        errorMessage = errMessage.DisplayErrorMessage(7);
                        Console.Write(errorMessage);
                        Console.ReadKey();

                    }
                    else
                    {
                        if (newData[2].ToUpper() != "A" && newData[2].ToUpper() != "SA")
                        {
                            Console.Clear();
                            errorMessage = errMessage.DisplayErrorMessage(7);
                            Console.Write(errorMessage);
                            Console.ReadKey();
                        }
                        else
                        {
                            tableData.Add($"row{tableData.Count + 1}", newData);
                            using (StreamWriter sw = new StreamWriter(filePath))
                            {
                                for (int i = 0; i < tableData.Count; i++)
                                {
                                    for (int x = 0; x < tableData.Values.ElementAt(i).Length; x++)
                                    {
                                        if (x > 1)
                                        {
                                            sw.Write(tableData.Values.ElementAt(i)[x]);
                                        }
                                        else
                                        {
                                            sw.Write(tableData.Values.ElementAt(i)[x] + ",");
                                        }
                                    }
                                    sw.WriteLine();
                                }

                                sw.Close();
                            }

                            Console.Write("Do you still want to add more data?: [y/N]\nAnswer: ");
                            userProc = Console.ReadLine();

                            if (userProc.ToLower() != "y" && userProc.ToLower() != "n")
                            {
                                Console.Clear();
                                errorMessage = errMessage.DisplayErrorMessage(7);
                                Console.Write(errorMessage);
                                Console.ReadKey();
                            }
                        }
                    }

                }
                else
                {

                    {
                        Console.Write("Pet Name: ");
                        newData[0] = Console.ReadLine().Trim();
                        Console.Write("Age: ");
                        newData[1] = Console.ReadLine().Trim();
                        Console.Write("Gender (Can only be [F | M]): ");
                        newData[2] = Console.ReadLine().Trim();

                        if (newData[2].Length > 1 || newData[2] == string.Empty)
                        {
                            Console.Clear();
                            errorMessage = errMessage.DisplayErrorMessage(7);
                            Console.Write(errorMessage);
                            Console.ReadKey();

                        }
                        else
                        {
                            if (newData[2].ToUpper() != "F" && newData[2].ToUpper() != "M")
                            {
                                Console.Clear();
                                errorMessage = errMessage.DisplayErrorMessage(7);
                                Console.Write(errorMessage);
                                Console.ReadKey();
                            }
                            else
                            {
                                tableData.Add($"row{tableData.Count + 1}", newData);
                                using (StreamWriter sw = new StreamWriter(filePath))
                                {
                                    for (int i = 0; i < tableData.Count; i++)
                                    {
                                        for (int x = 0; x < tableData.Values.ElementAt(i).Length; x++)
                                        {
                                            if (x > 1)
                                            {
                                                sw.Write(tableData.Values.ElementAt(i)[x]);
                                            }
                                            else
                                            {
                                                sw.Write(tableData.Values.ElementAt(i)[x] + ",");
                                            }
                                        }
                                        sw.WriteLine();
                                    }

                                    sw.Close();
                                }

                                Console.Write("Do you still want to add more data?: [y/N]\nAnswer: ");
                                userProc = Console.ReadLine();

                                if (userProc.ToLower() != "y" && userProc.ToLower() != "n")
                                {
                                    Console.Clear();
                                    errorMessage = errMessage.DisplayErrorMessage(7);
                                    Console.Write(errorMessage);
                                    Console.ReadKey();
                                }
                            }
                        }

                    }
                }
            }
        }

        public void searchData() 
        {
            checkTableExists();
            retrieveData();
            string userProc = string.Empty;
            string errorMessage = string.Empty;
            int rowIndex = 0;

            while (userProc.ToLower() != "n") 
            {
                Console.Clear();
                Console.Write("Type specific row number here: ");
                userProc = Console.ReadLine();

                if (!pattern.IsMatch(userProc))
                {
                    Console.Clear();
                    errorMessage = errMessage.DisplayErrorMessage(7);
                    Console.Write(errorMessage);
                    Console.ReadKey();
                }
                else
                {
                    if (int.Parse(userProc) > tableData.Count || int.Parse(userProc) < 1)
                    {
                        Console.Clear();
                        errorMessage = errMessage.DisplayErrorMessage(9);
                        Console.Write(errorMessage);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        rowIndex = int.Parse(userProc) - 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{tableData.Keys.ElementAt(rowIndex)}-> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"{tableData.Values.ElementAt(rowIndex)[0]} | {tableData.Values.ElementAt(rowIndex)[1]} | {tableData.Values.ElementAt(rowIndex)[2]}\n");
                        Console.Write("Search For another Data?: [y/N]\nAnswer: ");
                        userProc = Console.ReadLine();

                        if (userProc.ToLower() != "y" && userProc.ToLower() != "n") 
                        {
                            Console.Clear();
                            errorMessage = errMessage.DisplayErrorMessage(7);
                            Console.Write(errorMessage);
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void editData()
        {
            checkTableExists();
            retrieveData();
            string userProc = string.Empty;
            string errorMessage = string.Empty;
            int rowIndex = 0;
            string filePath = dbToManip == "1" ? "acc_table.csv" : "main_table.csv";
            string proc = string.Empty;

            while (userProc.ToLower() != "n")
            {
                Console.Clear();
                Console.Write("Type specific row number here: ");
                userProc = Console.ReadLine();
                string[] editData = new string[3];

                if (!pattern.IsMatch(userProc))
                {
                    Console.Clear();
                    errorMessage = errMessage.DisplayErrorMessage(7);
                    Console.Write(errorMessage);
                    Console.ReadKey();
                }
                else
                {
                    if (int.Parse(userProc) > tableData.Count || int.Parse(userProc) < 1)
                    {
                        Console.Clear();
                        errorMessage = errMessage.DisplayErrorMessage(9);
                        Console.Write(errorMessage);
                        Console.ReadKey();
                    }
                    else
                    {
                        if (dbToManip != "2")
                        {
                            Console.Clear();
                            rowIndex = int.Parse(userProc) - 1;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{tableData.Keys.ElementAt(rowIndex)}-> ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{tableData.Values.ElementAt(rowIndex)[0]} | {tableData.Values.ElementAt(rowIndex)[1]} | {tableData.Values.ElementAt(rowIndex)[2]}\n");

                            Console.Write("Name: ");
                            editData[0] = Console.ReadLine().Trim();
                            Console.Write("Password: ");
                            editData[1] = Console.ReadLine().Trim();
                            Console.Write("Authorization Level (Can only be [A | SA]): ");
                            editData[2] = Console.ReadLine().Trim();

                            for (int i = 0; i < editData.Length; i++) 
                            {
                                if (editData[i] != String.Empty)
                                {
                                    if (i == 2)
                                    {
                                        if (editData[i].ToUpper() != "A" && editData[i].ToUpper() != "SA")
                                        {
                                            Console.Clear();
                                            errorMessage = errMessage.DisplayErrorMessage(7);
                                            Console.Write(errorMessage);
                                            Console.ReadKey();
                                            proc = "no";
                                            break;
                                        }
                                        else
                                        {
                                            tableData.Values.ElementAt(rowIndex)[i] = editData[i];
                                            proc = "yes";
                                        }
                                  
                                    }
                                    else
                                    {
                                        tableData.Values.ElementAt(rowIndex)[i] = editData[i];
                                        proc = "yes";
                                    }
                                }
                                else
                                {                         
                                    proc = "yes";
                                }
                            }
                            if (proc != "no")
                                {
                                    using (StreamWriter sw = new StreamWriter(filePath))
                                    {
                                        for (int i = 0; i < tableData.Count; i++)
                                        {
                                            for (int x = 0; x < tableData.Values.ElementAt(i).Length; x++)
                                            {
                                                if (x > 1)
                                                {
                                                    sw.Write(tableData.Values.ElementAt(i)[x]);
                                                }
                                                else
                                                {
                                                    sw.Write(tableData.Values.ElementAt(i)[x] + ",");
                                                }
                                            }
                                            sw.WriteLine();
                                        }

                                        sw.Close();
                                    }
                                }
                            else
                            {
                                Console.Clear();
                                errorMessage = errMessage.DisplayErrorMessage(10);
                                Console.Write(errorMessage);
                                Console.ReadKey();
                            }         
                        }
                        else
                        {
                            Console.Clear();
                            rowIndex = int.Parse(userProc) - 1;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"{tableData.Keys.ElementAt(rowIndex)}-> ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"{tableData.Values.ElementAt(rowIndex)[0]} | {tableData.Values.ElementAt(rowIndex)[1]} | {tableData.Values.ElementAt(rowIndex)[2]}\n");

                            Console.Write("Pet Name: ");
                            editData[0] = Console.ReadLine().Trim();
                            Console.Write("Age: ");
                            editData[1] = Console.ReadLine().Trim();
                            Console.Write("Gender (Can only be [F | M]): ");
                            editData[2] = Console.ReadLine().Trim();

                            for (int i = 0; i < editData.Length; i++)
                            {
                                if (editData[i] != String.Empty)
                                {
                                    if (i == 2)
                                    {
                                        if (editData[i].ToUpper() != "F" && editData[i].ToUpper() != "M")
                                        {
                                            Console.Clear();
                                            errorMessage = errMessage.DisplayErrorMessage(7);
                                            Console.Write(errorMessage);
                                            Console.ReadKey();
                                            proc = "no";
                                            break;
                                        }
                                        else
                                        {
                                            tableData.Values.ElementAt(rowIndex)[i] = editData[i];
                                            proc = "yes";
                                        }

                                    }
                                    else
                                    {
                                        tableData.Values.ElementAt(rowIndex)[i] = editData[i];
                                        proc = "yes";
                                    }
                                }
                                else
                                {
                                    proc = "yes";
                                }
                            }
                            if (proc != "no")
                            {
                                using (StreamWriter sw = new StreamWriter(filePath))
                                {
                                    for (int i = 0; i < tableData.Count; i++)
                                    {
                                        for (int x = 0; x < tableData.Values.ElementAt(i).Length; x++)
                                        {
                                            if (x > 1)
                                            {
                                                sw.Write(tableData.Values.ElementAt(i)[x]);
                                            }
                                            else
                                            {
                                                sw.Write(tableData.Values.ElementAt(i)[x] + ",");
                                            }
                                        }
                                        sw.WriteLine();
                                    }

                                    sw.Close();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                errorMessage = errMessage.DisplayErrorMessage(10);
                                Console.Write(errorMessage);
                                Console.ReadKey();
                            }
                        }

                        Console.Clear();
                        Console.Write("Edit another Data?: [y/N]\nAnswer: ");
                        userProc = Console.ReadLine();

                        if (userProc.ToLower() != "y" && userProc.ToLower() != "n")
                        {
                            Console.Clear();
                            errorMessage = errMessage.DisplayErrorMessage(7);
                            Console.Write(errorMessage);
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void deleteData() 
        {
            checkTableExists();
            retrieveData();
            string userProc = string.Empty;
            string errorMessage = string.Empty;
            int rowIndex = 0;
            string filePath = dbToManip == "1" ? "acc_table.csv" : "main_table.csv";
            string proc = string.Empty;

            while (userProc.ToLower() != "n")
            {
                Console.Clear();
                Console.Write("Type specific row number here: ");
                userProc = Console.ReadLine();
                string[] editData = new string[3];

                if (!pattern.IsMatch(userProc))
                {
                    Console.Clear();
                    errorMessage = errMessage.DisplayErrorMessage(7);
                    Console.Write(errorMessage);
                    Console.ReadKey();
                }
                else
                {
                    if (int.Parse(userProc) > tableData.Count || int.Parse(userProc) < 1)
                    {
                        Console.Clear();
                        errorMessage = errMessage.DisplayErrorMessage(9);
                        Console.Write(errorMessage);
                        Console.ReadKey();
                    }
                    else
                    {
                        if (dbToManip != "2")
                        {                
                            rowIndex = int.Parse(userProc);
                            tableData.Remove($"row{rowIndex}");

                            using (StreamWriter sw = new StreamWriter(filePath))
                            {
                                for (int i = 0; i < tableData.Count; i++)
                                {
                                    for (int x = 0; x < tableData.Values.ElementAt(i).Length; x++)
                                    {
                                        if (x > 1)
                                        {
                                            sw.Write(tableData.Values.ElementAt(i)[x]);
                                        }
                                        else
                                        {
                                            sw.Write(tableData.Values.ElementAt(i)[x] + ",");
                                        }
                                    }
                                    sw.WriteLine();
                                }

                                sw.Close();
                            }
                           
                        }
                        else
                        {
                            rowIndex = int.Parse(userProc);
                            tableData.Remove($"row{rowIndex}");

                            using (StreamWriter sw = new StreamWriter(filePath))
                            {
                                for (int i = 0; i < tableData.Count; i++)
                                {
                                    for (int x = 0; x < tableData.Values.ElementAt(i).Length; x++)
                                    {
                                        if (x > 1)
                                        {
                                            sw.Write(tableData.Values.ElementAt(i)[x]);
                                        }
                                        else
                                        {
                                            sw.Write(tableData.Values.ElementAt(i)[x] + ",");
                                        }
                                    }
                                    sw.WriteLine();
                                }

                                sw.Close();
                            }                          
                        }

                        Console.Clear();
                        Console.Write("Delete another Data?: [y/N]\nAnswer: ");
                        userProc = Console.ReadLine();

                        if (userProc.ToLower() != "y" && userProc.ToLower() != "n")
                        {
                            Console.Clear();
                            errorMessage = errMessage.DisplayErrorMessage(7);
                            Console.Write(errorMessage);
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
    }
}
