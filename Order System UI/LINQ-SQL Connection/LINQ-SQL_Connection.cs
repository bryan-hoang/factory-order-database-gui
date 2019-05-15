using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_System_UI.LINQ_SQL_Connection
{
    /// <summary>
    /// Class for LINQ-SQL operations.
    /// </summary>
    public class LINQ_SQL_Connection
    {
        /// <summary>
        /// Declared attributes for LINQ-SQL operations.
        /// </summary>
        public TransportLinkDataContext DataContext;
        public List<TransportationDataLog1> TableData;
        public Table<TransportationDataLog1> List;

        /// <summary>
        /// Initializes a new instance of the <see cref="LINQ_SQL_Connection"/> class for LINQ-SQL operations.
        /// </summary>
        public LINQ_SQL_Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Order_System_UI.Properties.Settings.modelConnectionString"].ConnectionString;
            this.DataContext = new TransportLinkDataContext(connectionString);
            this.TableData = new List<TransportationDataLog1>();
            this.List = DataContext.TransportationDataLog1s;
        }// end constructor
    }// end class
}// end namespace
