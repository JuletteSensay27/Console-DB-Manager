using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_DB_Manager
{
    internal class accountLogin
    {
        private static showErrorMessage errMessage = new showErrorMessage();

        private Dictionary<string, string[]> userAccounts = new Dictionary<string, string[]>();

        private void retrieveData() 
        {
            string filePath = "acc_table.csv";
            string fileLine = string.Empty;
            string[] fileLineCont = new string[] { };
            int rowCounter = 0;

            if (!File.Exists(filePath))
            {
                string errorMessage = errMessage.DisplayErrorMessage(1);
                Console.Write(errorMessage);
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                using (StreamReader sr = new StreamReader(filePath)) 
                {
                    while ((fileLine = sr.ReadLine()) != null) 
                    {
                        fileLineCont = new string[fileLine.Split(',').Length];
                        fileLineCont = fileLine.Split(',');

                        userAccounts.Add($"row{rowCounter}", fileLineCont);
                        rowCounter++;
                    }
                }
            }
        }

        public bool login(string userName, string userPass) 
        {
            retrieveData();
            string[] tempCredChecker = new string[3];
            bool loginChecker = true;

            for (int i = 0; i < userAccounts.Count; i++) 
            {
                string tempUNChecker = userAccounts.Values.ElementAt(i)[0];

                if (userName == tempUNChecker) 
                {
                    for (int x = 0; x < userAccounts.Values.ElementAt(i).Length; x++) 
                    {
                        tempCredChecker[x] = userAccounts.Values.ElementAt(i)[x];
                    }            
                    break;
                }
            }

            if (tempCredChecker.ElementAt(0) == string.Empty) 
            {

            }

            return loginChecker;
        }
    }
}
