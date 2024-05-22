using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBookingConsoleApp
{
    public class DBConnection
    {
        public static SqlConnectionStringBuilder ConnectionBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-1U67J66",     // server name
            InitialCatalog = "DB",     // database name
            UserID = "sa",                         //user name
            Password = "sa@123",                  //server password
            TrustServerCertificate = true,
        };
    }
}
