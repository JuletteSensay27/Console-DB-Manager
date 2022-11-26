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
        private string filePath = "acc_table.csv";

        private Dictionary<string, string[]> userAccounts = new Dictionary<string, string[]>();

        private void retrieveData() 
        {
            userAccounts = new Dictionary<string, string[]>();
            string filePath = this.filePath;
            string fileLine = string.Empty;
            string[] fileLineCont = new string[] { };
            int rowCounter = 0;
                    
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

        public void checkTable() 
        {
            string filePath = this.filePath;
            if (!File.Exists(filePath))
            {
                string errorMessage = errMessage.DisplayErrorMessage(1);
                Console.Write(errorMessage);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public int login(string userName, string userPass) 
        {
            retrieveData();
            string[] tempCredChecker = new string[3];
            int loginChecker = 0;

            for (int i = 0; i < userAccounts.Count; i++) 
            {
                string tempUNChecker = userAccounts.Values.ElementAt(i)[0];

                if (tempUNChecker == userName) 
                {
                    for (int x = 0; x < userAccounts.Values.ElementAt(i).Length; x++) 
                    {
                        tempCredChecker[x] = userAccounts.Values.ElementAt(i)[x];
                    }            
                    break;
                }
            }

            if (tempCredChecker[0] == null)
            {            
                loginChecker = 2;
            }
            else
            {
                if (tempCredChecker[1] != userPass)
                {
                    loginChecker = 3;
                }
                else
                {
                    if (tempCredChecker[2] != "A" || tempCredChecker[2] != "SA")
                    {
                        loginChecker = 4;
                    }
                    else
                    {
                        loginChecker = 0;
                    }
                } 
            }

            return loginChecker;
        }
    }
}
