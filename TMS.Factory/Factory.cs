﻿using System;
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

        public Factory()
        {
            this.context = ConfigurationManager.AppSettings["context"];
            this.connectionstring = ConfigurationManager.ConnectionStrings[this.context].ConnectionString;
        }

        public Factory(IConfiguration config)
        {
            this.context = config.GetSection("Database")["Type"];
            this.connectionstring = config.GetSection("ConnectionStrings")[this.context];
        }

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
