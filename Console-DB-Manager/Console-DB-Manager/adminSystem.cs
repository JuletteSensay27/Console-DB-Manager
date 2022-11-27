using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_DB_Manager
{
    internal class adminSystem : dbOperations
    {
        private showErrorMessage errMess = new showErrorMessage();

        public void mainSystem()
        {
            string userProc = string.Empty;
            string[] tableOptions = new string[] { "1", "2", "Q", "q" };
            string[] procedureOptions = new string[] { "1", "2", "3", "4", "5", "Q", "q" };
            string tableToManip = string.Empty;

            while (userProc != "q")
            {
                Console.Clear();
                setDbToManip("2");
                
                 Console.Clear();
                 Console.Write("Choose an operation to perform:[1/2/3/4/5]\n\n\t1.Show Table Data\n\n\t2.Add Data to Table\n\n\t3. Search for specific table row\n\n\t4.Edit Specific table row\n\n\t5.Delete specific table row\n\n\tQ.Log Out\n\nAnswer: ");
                 userProc = Console.ReadLine();

                 if (!procedureOptions.Contains(userProc))
                 {
                     Console.Clear();
                     string errorMessage = errMess.DisplayErrorMessage(7);
                     Console.WriteLine(errorMessage);
                     Console.ReadKey();
                 }
                 else
                 {
                     switch (userProc)
                     {
                         case "1":
                             showData();
                             break;
                         case "2":
                             addData();
                             break;
                         case "3":
                             searchData();
                             break;
                         case "4":
                             editData();
                             break;
                         case "5":
                             deleteData();
                             break;                       
                         case "Q":
                             Console.Clear();
                             string errorMessage = errMess.DisplayErrorMessage(8);
                             Console.WriteLine(errorMessage);
                             break;
                         case "q":
                             Console.Clear();
                             errorMessage = errMess.DisplayErrorMessage(8);
                             Console.WriteLine(errorMessage);
                             break;
                     }
                 }
                
            }
        }
    }
}
