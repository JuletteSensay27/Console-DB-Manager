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

        static void Main(string[] args)
        {
            accLog.login("admin","pass");

            Console.ReadLine();
        }
    
    }
}
