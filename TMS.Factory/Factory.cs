using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using TMS.Dal.Interface;
using TMS.Dal.MEMORY;
using TMS.Dal.MSSQL;
using TMS.Logic;
using TMS.Logic.Interface;
using TMS.Repository;

namespace TMS.Factory
{
    public class Factory
    {
        private readonly string connectionstring;
        private readonly string context;

        /// <summary>
        /// This constructor is used when there are no parameters assigned (meant for windows form <XML>)
        /// </summary>
        public Factory()
        {
            this.context = ConfigurationManager.AppSettings["context"];
            this.connectionstring = ConfigurationManager.ConnectionStrings[this.context].ConnectionString;
        }

        /// <summary>
        /// This constructor is used when there are parameters assigned (meant for asp.net in specific core, reads appsettings.json)
        /// </summary>
        /// <param name="config"></param>
        public Factory(IConfiguration config)
        {
            this.context = config.GetSection("Database")["Type"];
            this.connectionstring = config.GetSection("ConnectionStrings")[this.context];
        }

        /// <summary>
        /// Creates the accountlogic (Everything related to account example: Create, read, update, delete and many more.)
        /// </summary>
        /// <returns>Returns logic behind account, Repository pattern to switch between context</returns>
        public IAccountLogic AccountLogic()
        {
            switch (this.context)
            {
                case "MSSQL": return new AccountLogic(new AccountRepository(new AccountMSSQLContext(this.connectionstring)));
                case "LOCAL": return new AccountLogic(new AccountRepository(new AccountMSSQLContext(this.connectionstring)));
                case "MEMORY": return new AccountLogic(new AccountRepository(new AccountMemoryContext()));
                default: throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Creates the orderlogic (Everything related to orders example: Create, read, update, delete and many more.)
        /// </summary>
        /// <returns>Returns logic behind order, Repository pattern to switch between context</returns>
        public IOrderLogic OrderLogic()
        {
            switch (this.context)
            {
                case "MSSQL": return new OrderLogic(new OrderRepository(new OrderMSSQLContext(this.connectionstring)));
                case "LOCAL": return new OrderLogic(new OrderRepository(new OrderMSSQLContext(this.connectionstring)));
                case "MEMORY": return new OrderLogic(new OrderRepository(new OrderMemoryContext()));
                default: throw new NotImplementedException();
            }
        }
    }
}
