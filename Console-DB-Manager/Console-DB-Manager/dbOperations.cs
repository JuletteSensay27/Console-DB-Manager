using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_DB_Manager
{
    internal class dbOperations
    {

        private static showErrorMessage errMessage = new showErrorMessage();

        private string dbToManip = string.Empty;

        private Dictionary<string, string[]> tableData = new Dictionary<string, string[]>();

        public void setDbToManip(string dbToManip) 
        {
            this.dbToManip = dbToManip;
        }

        private void retrieveData()
        {
            tableData = new Dictionary<string, string[]>();
            string filePath = dbToManip == "1" ? "acc_table.csv" : "main_table.csv" ;
            string fileLine = string.Empty;
            string[] fileLineCont = new string[] { };
            int rowCounter = 0;

            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((fileLine = sr.ReadLine()) != null)
                {
                    fileLineCont = new string[fileLine.Split(',').Length];
                    fileLineCont = fileLine.Split(',');

                    tableData.Add($"row{rowCounter}", fileLineCont);
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

            for (int x = 0; x < tableData.Count; x++) 
            {
                for (int y = 0; y < tableData.Values.ElementAt(x).Length; y++) 
                {
                    Console.WriteLine(tableData.Values.ElementAt(x)[y]);
                }
            }

            Console.ReadKey();
        }

    }
}
