using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_DB_Manager
{
    internal class showErrorMessage
    {

        /*
         * ERROR MESSAGE ARRAY ANATOMY
         * 
         * [0]: CONTAINS THE ERROR CODE
         * [1]: CONTAINS THE ERROR NAME
         * [2]: CONTAINS THE ERROR DESCRIPTION
         * 
        */

        private  string[] errorMessage = new string[3];

        private  void genErrorMessage(int errorCode) 
        {
            string[] temp = new string[3];

            switch (errorCode) 
            {
                case 0:
                    temp[0] = "0";
                    temp[1] = "NO ERROR";
                    temp[2] = "NO ERROR HAS BEEN DETECTED";
                    break;
                case 1:
                    temp[0] = "1";
                    temp[1] = "TABLE ERROR";
                    temp[2] = "TABLE NOT FOUND!";
                    break;
                case 2:
                    temp[0] = "2";
                    temp[1] = "LOGIN ERROR";
                    temp[2] = "ACCOUNT NOT FOUND! TRY AGAIN";
                    break;
                case 3:
                    temp[0] = "3";
                    temp[1] = "LOGIN ERROR";
                    temp[2] = "INCORRECT PASSWORD! TRY AGAIN";
                    break;
                case 4:
                    temp[0] = "4";
                    temp[1] = "LOGIN ERROR";
                    temp[2] = "YOUR ACCOUNT IS NOT AUTHORIZED TO LOGIN!";
                    break;
                case 5:
                    temp[0] = "5";
                    temp[1] = "LOGIN ERROR";
                    temp[2] = "TOO MANY ATTEMPTS! WILL END APPLICATION";
                    break;
            }

            for (int i = 0; i < errorMessage.Length; i++) 
            {
                errorMessage[i] = temp[i];
            }
        }

        public string DisplayErrorMessage(int errorCode) 
        {
            genErrorMessage(errorCode);
            string errorMessage = string.Empty;

            errorMessage = $"ERROR CODE:{this.errorMessage[0]}\nERROR NAME:{this.errorMessage[1]}\nERROR DESCRIPTION:{this.errorMessage[2]}";

            return errorMessage;
        }
    }
}
