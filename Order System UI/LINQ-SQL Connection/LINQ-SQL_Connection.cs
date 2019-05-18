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
    public class LinqSqlDeclaration
    {
        /// <summary>
        /// Declared attributes for LINQ-SQL operations.
        /// </summary>
        private readonly TransportLinkDataContext dataContext;
        private readonly List<TransportationDataLog> listData;
        private readonly Table<TransportationDataLog> table;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinqSqlDeclaration"/> class for LINQ-SQL operations.
        /// </summary>
        public LinqSqlDeclaration()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Order_System_UI.Properties.Settings.modelConnectionString"].ConnectionString;
            this.dataContext = new TransportLinkDataContext(connectionString);
            this.listData = new List<TransportationDataLog>();
            this.table = dataContext.TransportationDataLogs;
        }

        /// <summary>
        /// Gets the dataContext.
        /// </summary>
        public TransportLinkDataContext DataContext
        {
            get => this.dataContext;
        }

        /// <summary>
        /// Gets the tableData.
        /// </summary>
        public List<TransportationDataLog> ListData
        {
            get => this.listData;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        public Table<TransportationDataLog> Table
        {
            get => this.table;
        }// end property
    }// end class
}// end namespace