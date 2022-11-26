using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_DB_Manager
{
    internal class Program
    {
        private static accountLogin accLog = new accountLogin();
        private static showErrorMessage errMessage = new showErrorMessage();
        private static dbOperations dbOps = new dbOperations();

        static void Main(string[] args)
        {
            string userName = string.Empty;
            string userPassword = string.Empty;
            string errorMessage = string.Empty;          
            bool logChecker = true;
            int attemptCounter = 0;
            string authLevel = string.Empty;
           

            accLog.checkTable();
            
            while (logChecker) 
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Username: ");
                userName = Console.ReadLine();
                Console.Write("Password: ");
                userPassword = Console.ReadLine();

                if (accLog.login(userName, userPassword) != 6)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (accLog.login(userName, userPassword) == 3 || accLog.login(userName, userPassword) == 4) 
                    {
                        attemptCounter++;
                    }

                    if (attemptCounter > 3) 
                    {
                        errorMessage = errMessage.DisplayErrorMessage(5);
                        Console.WriteLine(errorMessage);
                        Task.Delay(3000).Wait();
                        Environment.Exit(0);
                    }

                    logChecker = true;
                    errorMessage = errMessage.DisplayErrorMessage(accLog.login(userName, userPassword));               
                    Console.WriteLine(errorMessage);
                    
                }
                else
                {
                    Console.Clear();
                    authLevel = accLog.getAuthorizationLevel();
                    errorMessage = errMessage.DisplayErrorMessage(accLog.login(userName, userPassword));
                    Console.WriteLine(errorMessage);
                    mainOperation(authLevel);
                    

                }
            
                Console.ReadKey();
            }
           

            Console.ReadLine();
        }

        private static void mainOperation(string authLevel)
        {
            string userProc = string.Empty;
            string dbToManip = string.Empty;
            string opToPerf = string.Empty;
            string[] dbsOps = new string[] { "1", "2", "q" };
            string[] mainOps = new string[] { "1", "2", "3", "4", "5", "q"  };
            string errorMessage = string.Empty;
            string hiddenOption = authLevel == "SA" ? "6. Choose another table\n\n\t" : string.Empty;
            string sixToShow = authLevel == "SA" ? "/6" : string.Empty;
            string empty = string.Empty;

            while (userProc.ToLower() != "q")
            {
                Console.Clear();

                if (dbToManip == String.Empty)
                {
                   

                    if (authLevel != "SA")
                    {
                        dbToManip = "2";
                        dbOps.setDbToManip(dbToManip);
                    }
                    else
                    {
                        Console.Write("SIMPLE DATABASE MANAGER\n\n");
                        Console.Write("Choose a Table to manipulate: [1/2]\n\n\t1.Accounts Table\n\n\t2.Main Table\n\n\tQ.Log Out\n\nAnswer: ");
                        userProc = Console.ReadLine();

                        for (int i = 0; i < dbsOps.Length; i++)
                        {
                            if (userProc != "q" || userProc != "Q")
                            {
                                if (userProc != "1" || userProc != "2")
                                {
                                    dbToManip = userProc;
                                    break;
                                }
                                else
                                {
                                    dbOps.setDbToManip(dbsOps[i]);
                                    dbToManip = dbsOps[i];
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.Clear();
                    }
                }


                if (userProc.ToLower() == "q")
                {
                    errorMessage = errMessage.DisplayErrorMessage(8);
                    Console.Write(errorMessage);
                }
                else if (dbToManip != "1" && dbToManip != "2" ) 
                {
                    errorMessage = errMessage.DisplayErrorMessage(7);
                    Console.Write(errorMessage);
                    dbToManip = String.Empty;
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Write("SIMPLE DATABASE MANAGER\n\n");
                    Console.Write("WELCOME!");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write($"Choose a Procedure to perform: [1/2/3/4/5{sixToShow}]\n\n\t1.Show Table Data\n\n\t2.Add Data to Table\n\n\t3.Search Specific Data from table\n\n\t4.Edit Specific Data from table\n\n\t5.Delete Specific Data from table\n\n\t{ hiddenOption }Q. Log Out\n\nAnswer: ");
                    userProc = Console.ReadLine();
                }
         
            }
        }
    }
}
