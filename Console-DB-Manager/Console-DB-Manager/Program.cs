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

        static void Main(string[] args)
        {
            string userName = string.Empty;
            string userPassword = string.Empty;
            string errorMessage = string.Empty;
            bool logChecker = true;
            int attemptCounter = 0;

            accLog.checkTable();
            
            while (logChecker) 
            {
                Console.Clear();
                Console.Write("Username: ");
                userName = Console.ReadLine();
                Console.Write("Password: "," ");
                userPassword = Console.ReadLine();

                if (accLog.login(userName, userPassword) != 0)
                {
                    if (accLog.login(userName, userPassword) == 3 || accLog.login(userName, userPassword) == 4) 
                    {
                        attemptCounter++;
                    }

                    if (attemptCounter > 3) 
                    {
                        Console.Clear();
                        errorMessage = errMessage.DisplayErrorMessage(5);
                        Console.WriteLine(errorMessage);
                        Console.ReadKey();
                        Environment.Exit(0);
                    }

                    logChecker = true;
                    errorMessage = errMessage.DisplayErrorMessage(accLog.login(userName, userPassword));
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    logChecker=false;
                }
            

                Console.ReadKey();
            }

            Console.ReadLine();
        }
    
    }
}
