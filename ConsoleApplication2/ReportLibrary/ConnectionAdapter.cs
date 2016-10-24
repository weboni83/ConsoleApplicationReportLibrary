using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportLibrary
{
    public class ConnectionAdapter
    {
        string DatabaseName { get; set; }
        bool IntegratedSecurity { get; set; }
        string Password { get; set; }
        string ServerName { get; set; }
        string UserID { get; set; }

        public void SetConnection(string server, string database, bool useIntegratedSecurity)
        {
            ServerName = server;
            DatabaseName = database;
            IntegratedSecurity = useIntegratedSecurity;
        }
        public void SetConnection(string server, string database, string user, string password)
        {
            ServerName = server;
            DatabaseName = database;
            UserID = user;
            Password = password;
        }
        public override String ToString()
        {
            return string.Format(@"{0},{1},{2},{3}", ServerName, DatabaseName, UserID, Password);
        }
    }
}
