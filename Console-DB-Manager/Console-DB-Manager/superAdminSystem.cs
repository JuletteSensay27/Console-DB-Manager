using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_DB_Manager
{
    internal class superAdminSystem : dbOperations
    {
        private showErrorMessage errMess = new showErrorMessage();

        public void mainSystem() 
        {
            string userProc = string.Empty;
            string[] tableOptions = new string[] { "1","2","Q","q" };
            string[] procedureOptions = new string[] {"1","2","3","4","5","6","Q","q" };
            string tableToManip = string.Empty;

            while (userProc != "q")
            {
                Console.Clear();
                if (tableToManip == string.Empty)
                {
                    Console.Write("Choose a table to manipulate:[1/2]\n\n\t1.Accounts Table\n\n\t2.Main Table\n\n\tQ.Log Out\n\nAnswer: ");
                    userProc = Console.ReadLine();

                    if (!tableOptions.Contains(userProc))
                    {
                        Console.Clear();
                        string errorMessage = errMess.DisplayErrorMessage(7);
                        Console.WriteLine(errorMessage);
                        Console.ReadKey();

                    }
                    else
                    {
                        for (int i = 0; i < tableOptions.Length; i++)
                        {
                            if (userProc != "Q" && userProc != "q")
                            {
                                if (userProc == tableOptions[i])
                                {
                                    tableToManip = tableOptions[i];
                                    setDbToManip(tableToManip);
                                    break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                string errorMessage = errMess.DisplayErrorMessage(8);
                                Console.WriteLine(errorMessage);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Choose an operation to perform:[1/2/3/4/5/6]\n\n\t1.Show Table Data\n\n\t2.Add Data to Table\n\n\t3. Search for specific table row\n\n\t4.Edit Specific table row\n\n\t5.Delete specific table row\n\n\t6.Choose another table\n\n\tQ.Log Out\n\nAnswer: ");
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
                            case "6":
                                tableToManip = string.Empty;
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
}
