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
        private static superAdminSystem supAds = new superAdminSystem();

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
            if (authLevel != "SA")
            {

            }
            else
            {
                supAds.mainSystem();
            }
        }
    }
}
