using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_DB_Manager
{
    internal class dbOperations
    {
        private string dbToManip = string.Empty;

        public void setDbToManip(string dbToManip) 
        {
            this.dbToManip = dbToManip;
        }

    }
}
